namespace Cik.Framework.Domain
{
    using System;
    using System.Collections.Generic;

    public class DomainEventPublisher
    {
        [ThreadStatic]
        static DomainEventPublisher instance;

        public static DomainEventPublisher Instance
        {
            get
            {
                return instance ?? (instance = new DomainEventPublisher());
            }
        }

        DomainEventPublisher()
        {
            this.publishing = false;
        }

        bool publishing;

        List<IDomainEventSubscriber<IDomainEvent>> subscribers;
        List<IDomainEventSubscriber<IDomainEvent>> Subscribers
        {
            get
            {
                return this.subscribers ?? (this.subscribers = new List<IDomainEventSubscriber<IDomainEvent>>());
            }
            set
            {
                this.subscribers = value;
            }
        }

        public void Publish<T>(T domainEvent) where T : IDomainEvent
        {
            if (this.publishing || !this.HasSubscribers())
            {
                return;
            }
            try
            {
                this.publishing = true;

                var eventType = domainEvent.GetType();

                foreach (var subscriber in this.Subscribers)
                {
                    var subscribedToType = subscriber.SubscribedToEventType();
                    if (eventType == subscribedToType || subscribedToType == typeof(IDomainEvent))
                    {
                        subscriber.HandleEvent(domainEvent);
                    }
                }
            }
            finally
            {
                this.publishing = false;
            }
        }

        public void PublishAll(ICollection<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                this.Publish(domainEvent);
            }
        }

        public void Reset()
        {
            if (!this.publishing)
            {
                this.Subscribers = null;
            }
        }

        public void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber)
        {
            if (!this.publishing)
            {
                this.Subscribers.Add(subscriber);
            }
        }

        public void Subscribe(Action<IDomainEvent> handle)
        {
            Subscribe(new DomainEventSubscriber<IDomainEvent>(handle));
        }

        class DomainEventSubscriber<TEvent> : IDomainEventSubscriber<TEvent>
            where TEvent : IDomainEvent
        {
            public DomainEventSubscriber(Action<TEvent> handle)
            {
                this.handle = handle;
            }

            readonly Action<TEvent> handle;

            public void HandleEvent(TEvent domainEvent)
            {
                this.handle(domainEvent);
            }

            public Type SubscribedToEventType()
            {
                return typeof(TEvent);
            }
        }

        bool HasSubscribers()
        {
            return this.subscribers != null && this.Subscribers.Count != 0;
        }
    }
}
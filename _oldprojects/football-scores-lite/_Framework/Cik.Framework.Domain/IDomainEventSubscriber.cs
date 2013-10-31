namespace Cik.Framework.Domain
{
    using System;

    public interface IDomainEventSubscriber<in T> where T : IDomainEvent
    {
        void HandleEvent(T domainEvent);
        Type SubscribedToEventType();
    }
}
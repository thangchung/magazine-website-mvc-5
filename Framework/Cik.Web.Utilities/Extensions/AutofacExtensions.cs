namespace Cik.Web.Utilities.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Autofac;
    using Autofac.Core;

    public static class AutofacExtensions
    {
        /// <summary>
        ///  http://stackoverflow.com/questions/4959148/is-it-possible-in-autofac-to-resolve-all-services-for-a-type-even-if-they-were 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IEnumerable<T> ResolveAll<T>(this IContainer container)
        {
            return ResolveAll(container, typeof(T)).Cast<T>();
        }

        public static IEnumerable<object> ResolveAll(this IContainer container, Type serviceType)
        {
            var allKeys = new List<object>();
            foreach (var componentRegistration in container.ComponentRegistry.Registrations)
            {
                var typedServices = componentRegistration.Services.Where(x => x is KeyedService).Cast<KeyedService>();
                allKeys.AddRange(typedServices.Where(y => y.ServiceType == serviceType).Select(x => x.ServiceKey));
            }

            var allUnKeyedServices = new List<object>(container.Resolve<IEnumerable<object>>());
            allUnKeyedServices.AddRange(allKeys.Select(key => container.ResolveKeyed<object>(key)));

            return allUnKeyedServices;
        }
    }
}
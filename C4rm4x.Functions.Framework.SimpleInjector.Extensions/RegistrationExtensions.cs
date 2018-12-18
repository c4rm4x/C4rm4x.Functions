#region Using

using SimpleInjector;
using System;
using System.Linq;
using System.Reflection;

#endregion

namespace C4rm4x.Functions.Framework.SimpleInjector
{
    /// <summary>
    /// Utilities methods to auto-register all the objects for SimpleInjector container
    /// </summary>
    public static class RegistrationExtensions
    {
        private static void RegisterTypeByAttribute<TAttr>(
               this Container container,
               params Assembly[] assemblies)
               where TAttr : Attribute
        {
            var registrations =
                assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(type =>
                    type.GetInterfaces().Any() &&
                    type.GetCustomAttributes(false).Any(a => a.GetType() == typeof(TAttr)))
                .Select(type => new { Services = type.GetInterfaces(), Implementation = type });

            foreach (var registration in registrations)
                foreach (var service in registration.Services)
                    container.Register(service, registration.Implementation, Lifestyle.Scoped);
        }

        /// <summary>
        /// Registers all public classes decorated with attribute Transformer within all specified assemblies
        /// </summary>
        /// <param name="container">The container</param>
        /// <param name="assemblies">List of assemblies</param>
        public static void RegisterAllTransformers(
            this Container container,
            params Assembly[] assemblies)
        {
            container.RegisterTypeByAttribute<TransformerAttribute>(assemblies);
        }

        /// <summary>
        /// Registers all public classes decorated with attribute DomainService within all specified assemblies
        /// </summary>
        /// <param name="container">The container</param>
        /// <param name="assemblies">List of assemblies</param>
        public static void RegisterAllDomainServices(
            this Container container,
            params Assembly[] assemblies)
        {
            container.RegisterTypeByAttribute<DomainServiceAttribute>(assemblies);
        }

        /// <summary>
        /// Registers all public classes decorated with attribute MessageHandler within all specified assemblies
        /// </summary>
        /// <param name="container">The container</param>
        /// <param name="assemblies">List of assemblies</param>
        public static void RegisterAllMessageHandlers(
            this Container container,
            params Assembly[] assemblies)
        {
            container.RegisterTypeByAttribute<MessageHandlerAttribute>(assemblies);
        }

        /// <summary>
        /// Registers all public classes decorated with attributes DomainService,
        /// Transformer and Repository within all specified assemblies
        /// </summary>
        /// <param name="container">The container</param>
        /// <param name="assemblies">List of assemblies</param>
        public static void RegisterAllDependencies(
            this Container container,
            params Assembly[] assemblies)
        {
            container.RegisterAllDomainServices(assemblies);
            container.RegisterAllTransformers(assemblies);
            container.RegisterAllMessageHandlers(assemblies);
        }
    }
}

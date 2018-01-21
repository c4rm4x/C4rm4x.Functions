#region Using

using SimpleInjector;
using System.Reflection;

#endregion

namespace C4rm4x.Functions.Framework.SimpleInjector
{
    #region Interface

    /// <summary>
    /// Represents a set of components and related functionality packaged together.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Apply the module to the container
        /// </summary>
        /// <param name="container">The container</param>
        void Configure(Container container);
    }

    #endregion

    /// <summary>
    /// Base implementation of IModule
    /// </summary>
    public abstract class Module : IModule
    {
        /// <summary>
        /// Apply the module to the container
        /// </summary>
        /// <param name="container">The container</param>
        public void Configure(Container container)
        {
            RegisterDependencies(container);
        }

        /// <summary>
        /// Registers dependencies to the SimpleInjector container
        /// </summary>
        /// <param name="container">The container</param>
        /// <remarks>
        /// Default implementation registers all objects
        /// </remarks>
        protected virtual void RegisterDependencies(Container container)
        {
            container.RegisterAllDependencies(ThisAssembly);
        }

        /// <summary>
        /// Gets the assembly in which the concrete module type is located
        /// </summary>
        protected virtual Assembly ThisAssembly
        {
            get { return this.GetType().Assembly; }
        }
    }
}

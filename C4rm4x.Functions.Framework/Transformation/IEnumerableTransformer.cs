#region Using

using System.Collections.Generic;

#endregion

namespace C4rm4x.Functions.Framework.Transformation
{
    /// <summary>
    /// Transform IEnumerable of objects of type S into D
    /// </summary>
    /// <typeparam name="S">Type of the source</typeparam>
    /// <typeparam name="D">Type of destination</typeparam>
    public interface IEnumerableTransformer<S, D> : ITransformer<S, D>
    {
        /// <summary>
        /// Transform all the sources
        /// </summary>
        /// <param name="sources">The sources</param>
        /// <returns>The destinations</returns>
        IEnumerable<D> Transform(IEnumerable<S> sources);
    }

    /// <summary>
    /// Transform IEnumerable of objects of type S into D using C as context
    /// </summary>
    /// <typeparam name="S">Type of the source</typeparam>
    /// <typeparam name="D">Type of destination</typeparam>
    /// <typeparam name="C">The of the context</typeparam>
    public interface IEnumerableTransformer<S, D, C> : ITransformer<S, D, C>
    {
        /// <summary>
        /// Transform all the sources using the context
        /// </summary>
        /// <param name="sources">The sources</param>
        /// <param name="context">The context</param>
        /// <returns>The destinations</returns>
        IEnumerable<D> Transform(IEnumerable<S> sources, C context);
    }
}

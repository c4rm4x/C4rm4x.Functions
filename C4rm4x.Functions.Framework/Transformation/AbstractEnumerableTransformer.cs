#region Using

using System.Collections.Generic;
using System.Linq;

#endregion

namespace C4rm4x.Functions.Framework.Transformation
{
    /// <summary>
    /// Transform IEnumerable of objects of type S into D
    /// </summary>
    /// <typeparam name="S">Type of the source</typeparam>
    /// <typeparam name="D">Type of destination</typeparam>
    public abstract class AbstractEnumerableTransformer<S, D> :
        IEnumerableTransformer<S, D>
    {
        /// <summary>
        /// Transforms the source
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>The destination</returns>
        public abstract D Transform(S source);

        /// <summary>
        /// Transform all the sources
        /// </summary>
        /// <param name="sources">The sources</param>
        /// <returns>The destinations</returns>
        public IEnumerable<D> Transform(IEnumerable<S> sources)
        {
            return sources.Select(Transform);
        }
    }

    /// <summary>
    /// Transform IEnumerable of objects of type S into D using C as context
    /// </summary>
    /// <typeparam name="S">Type of the source</typeparam>
    /// <typeparam name="D">Type of destination</typeparam>
    /// <typeparam name="C">Type of the context</typeparam>
    public abstract class AbstractEnumerableTransformer<S, D, C> :
        IEnumerableTransformer<S, D, C>
    {
        /// <summary>
        /// Transforms the source using the context
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="context">The context</param>
        /// <returns>The destination</returns>
        public abstract D Transform(S source, C context);

        /// <summary>
        /// Transform all the sources using the context
        /// </summary>
        /// <param name="sources">The sources</param>
        /// <param name="context">The context</param>
        /// <returns>The destinations</returns>
        public IEnumerable<D> Transform(IEnumerable<S> sources, C context)
        {
            return sources.Select(source => Transform(source, context));
        }
    }
}

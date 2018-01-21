namespace C4rm4x.Functions.Framework.Transformation
{
    /// <summary>
    /// Transform objects of type S into D
    /// </summary>
    /// <typeparam name="S">Type of the source</typeparam>
    /// <typeparam name="D">Type of destination</typeparam>
    public interface ITransformer<S, D>
    {
        /// <summary>
        /// Transforms the source
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>The destination</returns>
        D Transform(S source);
    }

    /// <summary>
    /// Transform objects of type S into D using C as context
    /// </summary>
    /// <typeparam name="S">Type of the source</typeparam>
    /// <typeparam name="D">Type of destination</typeparam>
    /// <typeparam name="C">The context</typeparam>
    public interface ITransformer<S, D, C>
    {
        /// <summary>
        /// Transforms the source using context 
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="context">The context</param>
        /// <returns>The destination</returns>
        D Transform(S source, C context);
    }
}

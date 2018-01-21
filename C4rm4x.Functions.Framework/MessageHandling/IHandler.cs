#region Using

using System.Threading.Tasks;

#endregion

namespace C4rm4x.Functions.Framework.MessageHandling
{
    /// <summary>
    /// Handles an specific type of message
    /// </summary>
    /// <typeparam name="TMessage">Type of message</typeparam>
    public interface IHandler<TMessage>
    {
        /// <summary>
        /// Handles a message of the specified type
        /// </summary>
        /// <param name="message">The message</param>
        Task HandleAsync(TMessage message);
    }
}

#region Using

using System;
using System.Collections.Generic;

#endregion

namespace C4rm4x.Functions.Framework
{
    /// <summary>
    /// Flags the underlying class as Message Handler
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageHandlerAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the types of the messages to handle
        /// </summary>
        public IEnumerable<Type> TypesToHandle { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="typesToHandle">Types of the messages to handle</param>
        public MessageHandlerAttribute(params Type[] typesToHandle)
        {
            TypesToHandle = typesToHandle;
        }
    }
}

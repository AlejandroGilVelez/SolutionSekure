using System;

namespace SC.Sekure.Helpers.Commons.Exceptions
{
    /// <summary>
    /// CustomException used for...
    /// </summary>
    public class CustomException : Exception
    {
        /// <sumary>
        /// DynamicData
        /// </sumary>
        public dynamic DynamicData { get; set; }

        /// <sumary>
        /// Constructor
        /// </sumary>
        public CustomException() { }

        /// <sumary>
        /// Constructor
        /// </sumary>
        /// <param name="message"></param>
        public CustomException(string message)
            : base(message) { }

        /// <sumary>
        /// Constructor
        /// </sumary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public CustomException(string message, Exception inner)
            : base(message, inner) { }

        /// <sumary>
        /// Constructor
        /// </sumary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public CustomException(string message, dynamic data) : base($"CustomException: {message}")
        {
            DynamicData = data;
        }
    }
}

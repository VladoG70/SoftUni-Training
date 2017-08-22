using System;

namespace BashSoft.Exceptions
    {
    public class InvalidPathException : Exception
        {
        private const string InvalidPath = "Invalid Destination. The source does not exist.";

        public InvalidPathException() : base(InvalidPath)
            { }

        public InvalidPathException(string message) : base(message)
            { }
        }
    }
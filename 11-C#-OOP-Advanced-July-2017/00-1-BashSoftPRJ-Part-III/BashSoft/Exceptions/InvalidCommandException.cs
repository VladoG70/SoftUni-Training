using System;

namespace BashSoft.Exceptions
    {
    public class InvalidCommandException : Exception
        {
        public const string InvalidCommand =
            "The command '{0}' is invalid or missing parameter.";

        public InvalidCommandException(string message) : base(String.Format(InvalidCommand, message))
            { }
        }
    }
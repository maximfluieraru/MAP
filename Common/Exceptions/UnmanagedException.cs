using System;

namespace Common.Exceptions
{
    public class UnmanagedException : Exception
    {
        public UnmanagedException() { }
        public UnmanagedException(string message) : base(message) { }
        public UnmanagedException(string message, Exception inner) : base(message, inner) { }
    }
}

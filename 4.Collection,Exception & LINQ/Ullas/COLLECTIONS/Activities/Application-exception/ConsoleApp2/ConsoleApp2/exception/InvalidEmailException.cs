namespace MyNamespace.exception;

 
    internal class InvalidEmailException : ApplicationException
    {
        public InvalidEmailException(string message) : base(message) { }
    }

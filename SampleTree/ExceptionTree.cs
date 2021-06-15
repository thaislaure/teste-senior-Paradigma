using System;

namespace SampleTree
{
    public class ExceptionTree : Exception
    {
        public ExceptionTree(string code, string message) : base(message)
        {
            this.Code = code;
        }

        public string Code { get; private set; }

        public string GetMessage() => $"{Code} - {Message}";
    }
}
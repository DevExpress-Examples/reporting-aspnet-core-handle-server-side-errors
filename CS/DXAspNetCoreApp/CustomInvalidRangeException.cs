using System;

namespace DXAspNetCoreApp {
    public class CustomInvalidRangeException : Exception {
        string message;
        public CustomInvalidRangeException(DateTime startDate, DateTime endDate, string prefixMessage) {
            message = prefixMessage;
            DetailedMessage = prefixMessage + $"\r\n Specified parameters: from '{startDate.ToShortDateString()}' to '{endDate.ToShortDateString()}'.";
        }
        public string DetailedMessage { get; private set; }
        public override string Message => message;
    }
}
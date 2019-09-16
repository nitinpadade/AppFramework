using System;

namespace Framework.Factory
{
    public class CommandResult
    {
        public CommandQueryStatus Status { get; private set; }

        public string Message { get; private set; }

        public string ErrorMessage { get; private set; }

        public Exception Exception { get; private set; }

        public object ReturnType { get; set; }

        public static CommandResult ReturnExecuted(string message, object returnType)
        {
            return new CommandResult()
            {
                Status = CommandQueryStatus.Executed,
                Message = message,
                ReturnType = returnType
            };
        }       

        public static CommandResult Executed(string message)
        {
            return new CommandResult()
            {
                Status = CommandQueryStatus.Executed,
                Message = message
            };
        }

        public static CommandResult Failed(string message, string errorMessage, Exception exception)
        {
            return new CommandResult()
            {
                Status = CommandQueryStatus.Failed,
                ErrorMessage = errorMessage,
                Message = message,
                Exception = exception
            };
        }

        public static CommandResult Warning(string message, string errorMessage)
        {
            return new CommandResult()
            {
                Status = CommandQueryStatus.Warning,
                ErrorMessage = errorMessage,
                Message = message
            };
        }

        public static CommandResult AccessDenied(string message, string errorMessage)
        {
            return new CommandResult()
            {
                Status = CommandQueryStatus.AccessDenied,
                ErrorMessage = errorMessage,
                Message = message
            };
        }

        public static CommandResult ReturnWarningWithObject(string message, string errorMessage, object returnType)
        {
            return new CommandResult()
            {
                Status = CommandQueryStatus.Warning,
                ErrorMessage = errorMessage,
                ReturnType = returnType,
                Message = message
            };
        }
    }
}

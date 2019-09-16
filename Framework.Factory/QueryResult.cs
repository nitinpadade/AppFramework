using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Factory
{
    public class QueryResult<T>
    {
        public T Data { get; set; }

        public bool IsExecuted { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }

        public CommandQueryStatus Status { get; set; }

    }
}

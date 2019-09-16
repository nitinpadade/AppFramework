using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Factory.Client
{
    public interface IQueryExecutor
    {
        TResult Execute<TCls, TResult, TParameters>(TParameters parameters)
          where TCls : class
          where TResult : class
           where TParameters : class;
    }
}

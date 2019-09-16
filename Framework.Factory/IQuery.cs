using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Factory
{
    public interface IQuery<TResult, TParameters>
    {
        TResult Execute(TParameters parameters);
    }
}

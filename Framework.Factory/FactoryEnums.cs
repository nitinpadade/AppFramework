using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Factory
{
    class FactoryEnums
    {
    }

    public enum CommandQueryStatus
    {
        Default = 0,
        Executed,
        Failed,
        Warning,
        AccessDenied
    }
}

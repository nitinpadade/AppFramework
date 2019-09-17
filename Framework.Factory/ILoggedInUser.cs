using Framework.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Factory
{
    public interface ILoggedInUser
    {
        CurrentUser Current(string[] userInfo); 
    }
}

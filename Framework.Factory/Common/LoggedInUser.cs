using System;
using System.Collections.Generic;
using System.Text;
using Framework.Data;

namespace Framework.Factory.Common
{
    public class LoggedInUser : ILoggedInUser
    {
        public LoggedInUser()
        {

        }

        public CurrentUser Current(string[] userInfo)
        {
            if (userInfo != null)
            {
                return new CurrentUser
                {
                    Id = Convert.ToInt32(userInfo[0]),
                    Name = userInfo[1],
                    RoleId = Convert.ToInt32(userInfo[2]),
                    RoleName = userInfo[3]
                };
            }
            else
                return new CurrentUser();
        }
    }
}

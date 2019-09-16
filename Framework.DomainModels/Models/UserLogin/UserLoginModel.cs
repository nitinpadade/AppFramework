using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DomainModels.Models.UserLogin
{
    public class UserLoginModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RoleId { get; set; }

        public string Role { get; set; }

        public bool IsAuthenticated { get; set; }

    }
}

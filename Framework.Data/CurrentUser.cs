using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public class CurrentUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}

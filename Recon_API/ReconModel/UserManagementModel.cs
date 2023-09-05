using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    public class UserManagementModel
    {
        public class Login_model
        {
            public string user_id { get; set; }
            public string user_name { get; set; }
            public string password { get; set; }
            public string datasource { get; set; }
            public string msg { get; set; }
            public string ip { get; set; }
        }
    }
}

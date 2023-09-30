using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

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

        public class change_password
        {
            public string user_id { get; set; }
            public string old_password { get; set; }
            public string new_password { get; set; }
            public string out_msg { get; set; }    
            public int out_result { get; set; }

        }

        public class headerValue
        {
            public string userCode { get; set; } = "";
            public string roleCode { get; set; } = "";
            public string langCode { get; set; } = "";
        }

    }
}

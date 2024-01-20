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
            public string user_code { get; set; } = "";
            public string role_code { get; set; } = "";
            public string lang_code { get; set; } = "";
            public string ip_address { get; set; } = "";
        }


        public class dashboardmodel
        {
            public string in_recon_code { get; set; }
            public string in_period_from { get; set;}
            public string in_period_to { get; set;}    
        }
		public class User_model
		{		
			public string user_code { get; set; }
			public string user_contact_no { get; set; }
			public string user_emailid { get; set; }
			public int user_gid { get; set; }
			public string user_name { get; set; }
			public string user_password { get; set; }
			public string action_by { get; set; }
			public int role_gid { get; set; }
			public String? out_msg { get; set; }
			public Int16? out_result { get; set; }
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
	public class CommonModel
	{
		public class errorlogModel
		{
			public string in_ip_addr { get; set; }
			public string in_source_name { get; set; }
			public string in_proc_name { get; set; }
			public string in_errorlog_text { get; set; }
			public string user_code { get; set; }

		}

		public class configvalueModel
		{
			public string in_config_name { get; set; }

		}
		public class roleconfig
		{
			public string in_screen_code { get; set; }
			public string add { get; set; }
			public string edit { get; set; }
			public string view { get; set; }
			public string delete { get; set; }
			public string process { get; set; }
			public string download { get; set; }
			public string deny { get; set; }
		}
		public class reconmindate
		{
			public string in_recon_code { get; set; }

		}
	}
}

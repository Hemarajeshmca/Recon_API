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
		}
	}
}

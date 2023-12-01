using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
	public class DatasettoReconmodel
	{
		public class DatasettoReconmodellist
		{
			public int in_user_gid { get; set; }
		}
		public class DatasettoReconmodelprocess
		{
			
			public int in_scheduler_gid { get; set; }
			public string in_ip_addr { get; set; }
		}

		public class ManualMatchinfoModel
		{
			public int in_scheduler_gid { get; set; }
		}

		public class runManualfileModel
		{
			public int in_scheduler_gid { get; set; }
			public string in_ip_addr { get; set; }

        }

    }
}

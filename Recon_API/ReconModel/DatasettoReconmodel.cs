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
			public int in_user_gid { get; set; }
			public int in_scheduler_gid { get; set; }
		}
	}
}

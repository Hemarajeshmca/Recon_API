using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
	public class ReconVersionmodel
	{
		public class ReconVersionmodellist
		{
			public string in_recon_code { get; set; }
		}
		public class ReconVersionmodelsave
		{
			public string in_recon_code { get; set; }
			public string in_rule_code { get; set; }
			public string in_reconrule_version { get; set; }
			public string in_user_code { get; set; }
		}
	}
}

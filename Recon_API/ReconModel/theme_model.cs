using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
	public class theme_model
	{
		public class themeHeadermodel
		{
			public string? theme_name { get; set; }
			public string theme_Code { get; set; }
			public string theme_order { get; set; }
			public Int32 theme_gid { get; set; }
			public string? recon_code { get; set; }
			public string? active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_action_by { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
			public string clone_theme { get; set; }
			public string holdflag { get; set; }
		}

		public class themedetailmodel
		{
			public Int32 themefilter_gid { get; set; }
			public Int32 theme_seqno { get; set; }
			public string theme_code { get; set; }
			public string recon_field { get; set; }
			public string filter_criteria { get; set; }
			public string filter_value { get; set; }
			public string open_flag { get; set; }
			public string close_flag { get; set; }
			public string join_condition { get; set; }
			public string? active_status { get; set; }
			public string? action { get; set; }
			public string? in_user_code { get; set; }
		}
		public class themeDetailmodel
		{			
			public string theme_Code { get; set; }
		}
		public class themelistmodel
		{
			public string recon_code { get; set; }
		}
	}
}

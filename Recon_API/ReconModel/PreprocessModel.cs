using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    public class PreprocessModel
    {
		public class Preprocesslistmodel
		{
			public string? recon_code { get; set; }
		}
		public class preprocessHeadermodel
		{
			public string? preprocess_name { get; set; }
			public string? preprocess_Code { get; set; }
			public Int32 preprocess_gid { get; set; }
			public string? recon_code { get; set; }
			public string? get_recon_field { get; set; }
			public string? set_recon_field { get; set; }
			public string? process_method { get; set; }
			public string? process_query { get; set; }
			public string? process_function { get; set; }
			public string? preprocess_order { get; set; }
			public string? lookup_dataset_code { get; set; }
			public string? lookup_return_field { get; set; }
			public string? active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_action_by { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
			public string? clone_process { get; set; }
		}
	}
}

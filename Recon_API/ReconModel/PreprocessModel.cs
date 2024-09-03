using Microsoft.Extensions.Hosting;
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
			public string? in_returnflag { get; set; }
			public string? lookup_multi_return_flag { get; set; }
			public string? active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_action_by { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
			public string? clone_process { get; set; }
			public string? hold_flag { get; set; }
		}
		public class filterdata
		{
			public int? in_preprocessfilter_gid { get; set; }
			public string? in_preprocess_code { get; set; }
			public string? in_recon_code { get; set; }
			public Double in_filter_seqno { get; set; }
			public string? in_filter_field { get; set; }
			public string? in_filter_criteria { get; set; }
			public string? in_ident_value_flag { get; set; }
			public string? in_ident_value { get; set; }
			public string? in_open_flag { get; set; }
			public string? in_close_flag { get; set; }
			public string? in_join_condition { get; set; }
			public string? in_active_status { get; set; }
			public string? in_filter_applied_on { get; set; }
			public string? in_action { get; set; }
			public string? in_user_code { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
		public class Preprocessfetchmodel
		{
			public string? preprocess_code { get; set; }
		}
		public class getConditionlook
		{
			public String? in_condition_type { get; set; }
			public String? in_field_type { get; set; }
			public String? in_dataset_code { get; set; }

		}
		public class conditiondata
		{
			public int? in_preprocesscondition_gid { get; set; }
			public string? in_preprocess_code { get; set; }
			public string? in_Ldataset_code { get; set; }
			public string? in_Lreturn_field { get; set; }
			public string? in_setrecon_field { get; set; }
			public Double in_condition_seqno { get; set; }
			public string? in_recon_field { get; set; }
			public string? in_extraction_criteria { get; set; }
			public string? in_extraction_filter { get; set; }
			public string? in_lookup_field { get; set; }
			public string? in_comparison_criteria { get; set; }
			public string? in_comparison_filter { get; set; }
			public string? in_source_field_type { get; set; }
			public string? in_open_flag { get; set; }
			public string? in_close_flag { get; set; }
			public string? in_join_condition { get; set; }
			public string? in_returnflag { get; set; }
			public string? in_active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_action_by { get; set; }
		}
		public class Validatequerymodel
		{
			public string in_sql { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
		public class Preprocesslistmodelclone
		{
			public string? recon_code { get; set; }
		}
		public class clonepreprocessModel
		{
			public String? in_preprocess_name { get; set; }
			public String? in_clone_preprocess_code { get; set; }
		}
		public class lookupfieldmodel
		{
			public int? in_preprocesslookup_gid { get; set; }
			public string? in_preprocess_code { get; set; }
			public Double in_lookup_seqno { get; set; }
			public string? in_lookup_return_field { get; set; }
			public string? in_set_recon_field { get; set; }
			public string? in_active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_user_code { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
	}
}

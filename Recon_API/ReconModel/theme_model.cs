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
			public string theme_name { get; set; }
			public string theme_Code { get; set; }
			public string theme_order { get; set; }
			public Int32 theme_gid { get; set; }
			public string recon_code { get; set; }
			public string active_status { get; set; }
			public string in_action { get; set; }
			public string in_action_by { get; set; }
			public string out_msg { get; set; }
			public string out_result { get; set; }
			public string theme_type { get; set; }
			public string source_dataset { get; set; }
			public string comparison_dataset { get; set; }
			public string inactive_reason { get; set; }
		}

		public class themedetailmodel
		{
			public Int32 themefilter_gid { get; set; }
			public decimal themefilter_seqno { get; set; }
			public string theme_code { get; set; }
			public string filter_applied_on { get; set; }
			public string filter_field { get; set; }
			public string filter_criteria { get; set; }
			public string filter_value { get; set; }
			public string open_flag { get; set; }
			public string close_flag { get; set; }
			public string join_condition { get; set; }
			public string? active_status { get; set; }
			public string? action { get; set; }
			public string? in_user_code { get; set; }
		}
		public class themeDetailmodelfetch
		{			
			public string theme_Code { get; set; }
		}
		public class themelistmodel
		{
			public string recon_code { get; set; }
		}
		public class ThemeCondition
		{
			public int? in_themecondition_gid { get; set; }
			public string? in_theme_code { get; set; }
			public Decimal? in_themecondition_seqno { get; set; }
			public string? in_source_field { get; set; }
			public string? in_comparison_field { get; set; }
			public string? in_extraction_criteria { get; set; }
			public string? in_comparison_criteria { get; set; }
			public string? in_open_flag { get; set; }
			public string? in_close_flag { get; set; }
			public string? in_join_condition { get; set; }
			public string? in_active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_user_code { get; set; }
		}
		public class themegrouping
		{
			public int? in_themegrpfield_gid { get; set; }
			public Decimal? themegrpfield_seqno { get; set; }
			public string? in_grp_field { get; set; }
			public string? in_theme_code { get; set; }
			public string? grpfield_applied_on_code { get; set; }
			public string? in_active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_user_code { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
		public class Aggfunction
		{
			public int? themeaggfield_gid { get; set; }
			public Decimal? themeaggfield_seqno { get; set; }
			public string? recon_field { get; set; }
			public string? themeaggfield_applied_on { get; set; }
			public string? themeaggfield_name { get; set; }
			public string? themeagg_function { get; set; }
			public string? in_theme_code { get; set; }
			public string? in_active_status { get; set; }
			public string? in_action { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
		public class Aggcondition
		{
			public int? themeaggcondition_gid { get; set; }
			public Decimal? themeaggcondition_seqno { get; set; }			
			public string? themeagg_applied_on { get; set; }
			public string? themeagg_field { get; set; }
			public string? themeagg_criteria { get; set; }
			public string? themeagg_value_flag { get; set; }
			public string? themeagg_value { get; set; }
			public string? in_theme_code { get; set; }
			public string? in_open_flag { get; set; }
			public string? in_close_flag { get; set; }
			public string? in_join_condition { get; set; }
			public string? in_active_status { get; set; }
			public string? in_action { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
		public class getConditiontheme
		{
			public String? in_condition_type { get; set; }
			public String? in_field_type { get; set; }
			public String? in_theme_code { get; set; }

		}
	}
}

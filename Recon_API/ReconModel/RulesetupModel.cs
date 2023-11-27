using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels

{
    public class RulesetupModel

    {
        public class Rulesetuplist
        {
            public String? in_user_code { get; set; }
			public string? in_recon_code { get; set; }
		}

        public class Rulesetupheader
        {
            public Int64? in_rule_gid { get; set; }
            public string? in_rule_code { get; set; }
            public string? in_rule_name { get; set; }
            public string? in_recon_code { get; set; }
            public DateOnly in_period_from { get; set; }
            public DateOnly? in_period_to { get; set; }
            public string? in_until_active_flag { get; set; }
            public Decimal? in_rule_order { get; set; }
            public string? in_applyrule_on { get; set; }
            public string? in_source_dataset_code { get; set; }
            public string? in_comparison_dataset_code { get; set; }
            public string? in_source_acc_mode { get; set; }
            public string? in_comparison_acc_mode { get; set; }
            public string? in_parent_dataset_code { get; set; }
           // public string? in_support_dataset_code { get; set; }
            public string? in_parent_acc_mode { get; set; }
           // public string? in_reversal_flag { get; set; }
            public string? in_group_flag { get; set; }
            public string? in_active_status { get; set; }
            public string? in_action { get; set; }
            public string? in_user_code { get; set; }
        }

        public class Rulegrouping
        {
            public int? in_rulegrpfield_gid { get; set; }               
            public string? in_grp_field { get; set; }
            public string? in_rule_code { get; set; }
            public string? in_active_status { get; set; }
            public string? in_action { get; set; }
            public string? in_user_code { get; set; }
        }

        public class RuleIdentifier
        {
            public int? in_ruleselefilter_gid { get; set; }
            public string? in_rule_code { get; set; }
            public string? in_filter_applied_on { get; set; }
            public string? in_filter_field { get; set; }
            public string? in_filter_criteria { get; set; }
            public string? in_ident_criteria { get; set; }
            public string? in_ident_value { get; set; }
			public string? in_open_flag { get; set; }
			public string? in_close_flag { get; set; }
			public string? in_join_condition { get; set; }
			public string? in_active_status { get; set; }
            public string? in_action { get; set; }
            public string? in_user_code { get; set; }
        }
        public class RuleCondition
        {
            public int? in_rulecondition_gid { get; set; }
            public string? in_rule_code { get; set; }
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

        public class fetchRule
        {
            public string? in_rule_code { get; set; }
        }
		public class Rulefieldorder
		{
			public int? in_rulerecorder_gid { get; set; }			
			public string? in_rule_code { get; set; }
			public string? in_recorder_applied_on { get; set; }
			public int? in_recorder_seqno { get; set; }
			public string? in_recorder_field { get; set; }
			public string? in_active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_user_code { get; set; }
		}
	}
}

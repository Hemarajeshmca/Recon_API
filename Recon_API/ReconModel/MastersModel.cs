using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    internal class MastersModel
    {
    }
        public class Reconfieldmapping
    {
            public Int16? in_reconfieldmapping_gid { get; set; }
            public String in_recon_code { get; set; }
            public String in_filetemplate_code { get; set; }
            public String in_acc_code { get; set; }
            public String in_recon_field_name { get; set; }
            public String in_filetemplate_field_name { get; set; }
            public String in_action { get; set; }
            public String in_action_by { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }

    public class Recon
    {
        public Int16? in_recon_gid { get; set; }
        public String in_recon_code { get; set; }
        public String in_recon_name { get; set; }
        public String in_recontype_code { get; set; }
        public String in_recon_automatch_partial { get; set; }
        public DateOnly in_period_from { get; set; }
        public DateOnly in_period_to { get; set; }
        public String in_until_active_flag { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }

    public class Reconacc
    {
        public Int16? in_reconacc_gid { get; set; }
        public String in_recon_code { get; set; }
        public String in_acc_code { get; set; }
        public String in_source_acc_flag { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }

    public class Reconfield
    {
        public Int16? in_reconfield_gid { get; set; }
        public String in_recon_code { get; set; }
        public String in_field_name { get; set; }
        public String in_field_alias_name { get; set; }
        public String in_fieldtype_code { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }

    public class Acc
    {
        public Int16? in_acc_gid { get; set; }
        public String in_acc_code { get; set; }
        public String in_acc_name { get; set; }
        public String in_acc_category { get; set; }
        public String in_acc_responsibility { get; set; } 
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }

    public class Reconfiletemplate
    {
        public Int16? in_reconfiletemplate_gid { get; set; }
        public String in_recon_code { get; set; }
        public String in_filetemplate_code { get; set; }
        public String in_acc_code { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Mstrule
    {
        public Int16? in_rule_gid { get; set; }
        public String in_recon_code { get; set; }
        public String in_rule_code { get; set; }
        public String in_rule_name { get; set; }
        public DateOnly in_period_from { get; set; }
        public DateOnly in_period_to { get; set; }
        public String in_until_active_flag { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Filetemplatefield
    {
        public Int16? in_filetemplatefield_gid { get; set; }
        public String in_filetemplate_code { get; set; }
        public String in_excel_field { get; set; }
        public Int16 in_csv_column_no { get; set; }
        public String in_field_name { get; set; }
        public String in_conversion_criteria { get; set; }
        public String in_mandatory_field { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }

    public class Filetemplate
    {
        public Int16? in_filetemplate_gid { get; set; }
        public String in_filetemplate_code { get; set; }
        public String in_filetemplate_name { get; set; }
        public String in_templatetype_code { get; set; }
        public String in_filetype_code { get; set; }
        public Int16 in_csv_columns { get; set; }
        public String in_csv_seperator { get; set; }
        public String in_header_flag { get; set; }
        public String in_acc_code_flag { get; set; }
        public String in_tran_value_flag { get; set; }
        public String in_tran_valuetype_code { get; set; }
        public String in_bal_value_flag { get; set; }
        public String in_bal_valuetype_code { get; set; }
        public String in_tran_date_flag { get; set; }
        public String in_tran_date_format { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Rulefield
    {
        public Int16? in_rulefield_gid { get; set; }
        public String in_rule_code { get; set; }
        public String in_source_field { get; set; }
        public String in_extraction_criteria { get; set; }
        public String in_extraction_filter { get; set; }
        public String in_target_field { get; set; }
        public String in_comparison_criteria { get; set; }
        public String in_comparison_filter { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Applyrule
    {
        public Int16? in_applyrule_gid { get; set; }
        public String in_applyrule_code { get; set; }
        public String in_recon_code { get; set; }
        public String in_applyrule_on { get; set; }
        public String in_tranbrkptype_code { get; set; }
        public String in_system_match_flag { get; set; }
        public String in_manual_match_flag { get; set; }
        public DateOnly in_period_from { get; set; }
        public DateOnly in_period_to { get; set; }
        public String in_until_active_flag { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Applyruledtl
    {
        public Int16? in_applyruledtl_gid { get; set; }
        public String in_applyruledtl_code { get; set; }
        public String in_applyrule_code { get; set; }
        public String in_rule_code { get; set; }
        public String in_group_flag { get; set; }
        public String in_group_method_flag { get; set; }
        public String in_manytomany_match_flag { get; set; }
        public String in_reversal_flag { get; set; }
        public Decimal in_rule_order { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Applyrule_addcond
    {
        public Int16? in_applyrule_addcond_gid { get; set; }
        public String in_applyrule_code { get; set; }
        public String in_applyruledtl_code { get; set; }
        public String in_source_field { get; set; }
        public String in_extraction_criteria { get; set; }
        public String in_extraction_filter { get; set; }
        public String in_target_field { get; set; }
        public String in_comparison_criteria { get; set; }
        public String in_comparison_filter { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Applyrule_targetgrpfield
    {
        public Int16? in_applyrule_targetgrpfield_gid { get; set; }
        public String in_applyrule_code { get; set; }
        public String in_applyruledtl_code { get; set; }
        public String in_applyrule_basesele_code { get; set; }
        public String in_targetgrp_field { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Applyrule_basesele
    {
        public Int16? in_applyrule_basesele_gid { get; set; }
        public String in_applyrule_basesele_code { get; set; }
        public String in_applyrule_code { get; set; }
        public String in_applyruledtl_code { get; set; }
        public String in_base_acc_code { get; set; }
        public String in_base_acc_mode { get; set; }
        public String in_target_acc_code { get; set; }
        public String in_target_acc_mode { get; set; }
        public Decimal in_sele_order { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
    public class Applyrule_basefilter
    {
        public Int16? in_applyrule_basefilter_gid { get; set; }
        public String in_applyrule_basefilter_code { get; set; }
        public String in_applyrule_code { get; set; }
        public String in_applyruledtl_code { get; set; }
        public String in_applyrule_basesele_code { get; set; }
        public String in_filter_applied_on { get; set; }
        public String in_filter_field { get; set; }
        public String in_filter_criteria { get; set; }
        public Int16 in_add_filter { get; set; }
        public String in_ident_criteria { get; set; }
        public String in_ident_value { get; set; }
        public String in_active_status { get; set; }
        public String in_action { get; set; }
        public String in_action_by { get; set; }
        public String? out_msg { get; set; }
        public Int16? out_result { get; set; }
    }
}

using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconDataLayer
{
    public class MastersData
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public List<IDbDataParameter> parameters;
        public DBManager dbManager = new DBManager("ConnectionString");

        public DataSet Reconfieldmapping(Reconfieldmapping reconfieldmapping)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_reconfieldmapping_gid", reconfieldmapping.in_reconfieldmapping_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_recon_code", reconfieldmapping.in_recon_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_filetemplate_code", reconfieldmapping.in_filetemplate_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_code", reconfieldmapping.in_acc_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recon_field_name", reconfieldmapping.in_recon_field_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_filetemplate_field_name", reconfieldmapping.in_filetemplate_field_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", reconfieldmapping.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", reconfieldmapping.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_treconfieldmapping", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Recon(Recon recon)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_gid", recon.in_recon_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_recon_code", recon.in_recon_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recon_name", recon.in_recon_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recontype_code", recon.in_recontype_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recon_automatch_partial", recon.in_recon_automatch_partial, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_period_from", recon.in_period_from, DbType.Date));

                parameters.Add(dbManager.CreateParameter("in_period_to", recon.in_period_to, DbType.Date));

                parameters.Add(dbManager.CreateParameter("in_until_active_flag", recon.in_until_active_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", recon.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", recon.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", recon.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_trecon", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Reconacc(Reconacc reconacc)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_reconacc_gid", reconacc.in_reconacc_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_recon_code", reconacc.in_recon_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_code", reconacc.in_acc_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_source_acc_flag", reconacc.in_source_acc_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", reconacc.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", reconacc.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", reconacc.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_treconacc", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Reconfield(Reconfield reconfield)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_reconfield_gid", reconfield.in_reconfield_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_recon_code", reconfield.in_recon_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_field_name", reconfield.in_field_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_field_alias_name", reconfield.in_field_alias_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_fieldtype_code", reconfield.in_fieldtype_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", reconfield.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", reconfield.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_treconfield", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Acc(Acc acc)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_acc_gid", acc.in_acc_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_acc_code", acc.in_acc_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_name", acc.in_acc_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_category", acc.in_acc_category, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_responsibility", acc.in_acc_responsibility, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", acc.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", acc.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", acc.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tacc", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Reconfiletemplate(Reconfiletemplate reconfiletemplate)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_reconfiletemplate_gid", reconfiletemplate.in_reconfiletemplate_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_recon_code", reconfiletemplate.in_recon_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_filetemplate_code", reconfiletemplate.in_filetemplate_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_code", reconfiletemplate.in_acc_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", reconfiletemplate.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", reconfiletemplate.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", reconfiletemplate.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_treconfiletemplate", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Mstrule(Mstrule mstrule)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_rule_gid", mstrule.in_rule_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_recon_code", mstrule.in_recon_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_rule_code", mstrule.in_rule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_rule_name", mstrule.in_rule_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_period_from", mstrule.in_period_from, DbType.Date));

                parameters.Add(dbManager.CreateParameter("in_period_to", mstrule.in_period_to, DbType.Date));

                parameters.Add(dbManager.CreateParameter("in_until_active_flag", mstrule.in_until_active_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", mstrule.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", mstrule.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", mstrule.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_trule", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Filetemplatefield(Filetemplatefield filetemplatefield)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_filetemplatefield_gid", filetemplatefield.in_filetemplatefield_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_filetemplate_code", filetemplatefield.in_filetemplate_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_excel_field", filetemplatefield.in_excel_field, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_csv_column_no", filetemplatefield.in_csv_column_no, DbType.Int16));

                parameters.Add(dbManager.CreateParameter("in_field_name", filetemplatefield.in_field_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_conversion_criteria", filetemplatefield.in_conversion_criteria, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_mandatory_field", filetemplatefield.in_mandatory_field, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", filetemplatefield.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", filetemplatefield.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", filetemplatefield.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tfiletemplatefield", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Filetemplate(Filetemplate filetemplate)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_filetemplate_gid", filetemplate.in_filetemplate_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_filetemplate_code", filetemplate.in_filetemplate_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_filetemplate_name", filetemplate.in_filetemplate_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_templatetype_code", filetemplate.in_templatetype_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_filetype_code", filetemplate.in_filetype_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_csv_columns", filetemplate.in_csv_columns, DbType.Int16));

                parameters.Add(dbManager.CreateParameter("in_csv_seperator", filetemplate.in_csv_seperator, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_header_flag", filetemplate.in_header_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_code_flag", filetemplate.in_acc_code_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_tran_value_flag", filetemplate.in_tran_value_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_tran_valuetype_code", filetemplate.in_tran_valuetype_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_bal_value_flag", filetemplate.in_bal_value_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_bal_valuetype_code", filetemplate.in_bal_valuetype_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_tran_date_flag", filetemplate.in_tran_date_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_tran_date_format", filetemplate.in_tran_date_format, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", filetemplate.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", filetemplate.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", filetemplate.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tfiletemplate", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Rulefield(Rulefield rulefield)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_rulefield_gid", rulefield.in_rulefield_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_rule_code", rulefield.in_rule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_source_field", rulefield.in_source_field, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_extraction_criteria", rulefield.in_extraction_criteria, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_extraction_filter", rulefield.in_extraction_filter, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_target_field", rulefield.in_target_field, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_comparison_criteria", rulefield.in_comparison_criteria, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_comparison_filter", rulefield.in_comparison_filter, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", rulefield.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", rulefield.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", rulefield.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_trulefield", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Applyrule(Applyrule applyrule)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_applyrule_gid", applyrule.in_applyrule_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_applyrule_code", applyrule.in_applyrule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recon_code", applyrule.in_recon_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyrule_on", applyrule.in_applyrule_on, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_tranbrkptype_code", applyrule.in_tranbrkptype_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_system_match_flag", applyrule.in_system_match_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_manual_match_flag", applyrule.in_manual_match_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_period_from", applyrule.in_period_from, DbType.Date));

                parameters.Add(dbManager.CreateParameter("in_period_to", applyrule.in_period_to, DbType.Date));

                parameters.Add(dbManager.CreateParameter("in_until_active_flag", applyrule.in_until_active_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", applyrule.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", applyrule.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", applyrule.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tapplyrule", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Applyruledtl(Applyruledtl applyruledtl)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_applyruledtl_gid", applyruledtl.in_applyruledtl_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_applyruledtl_code", applyruledtl.in_applyruledtl_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyrule_code", applyruledtl.in_applyrule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_rule_code", applyruledtl.in_rule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_group_flag", applyruledtl.in_group_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_group_method_flag", applyruledtl.in_group_method_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_manytomany_match_flag", applyruledtl.in_manytomany_match_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_reversal_flag", applyruledtl.in_reversal_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_rule_order", applyruledtl.in_rule_order, DbType.Decimal));

                parameters.Add(dbManager.CreateParameter("in_active_status", applyruledtl.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", applyruledtl.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", applyruledtl.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tapplyruledtl", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Applyrule_addcond(Applyrule_addcond applyruleaddcond)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_applyrule_addcond_gid", applyruleaddcond.in_applyrule_addcond_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_applyrule_code", applyruleaddcond.in_applyrule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyruledtl_code", applyruleaddcond.in_applyruledtl_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_source_field", applyruleaddcond.in_source_field, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_extraction_criteria", applyruleaddcond.in_extraction_criteria, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_extraction_filter", applyruleaddcond.in_extraction_filter, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_target_field", applyruleaddcond.in_target_field, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_comparison_criteria", applyruleaddcond.in_comparison_criteria, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_comparison_filter", applyruleaddcond.in_comparison_filter, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", applyruleaddcond.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", applyruleaddcond.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", applyruleaddcond.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tapplyrule_addcond", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Applyrule_targetgrpfield(Applyrule_targetgrpfield applyruletargetgrpfield)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_applyrule_targetgrpfield_gid", applyruletargetgrpfield.in_applyrule_targetgrpfield_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_applyrule_code", applyruletargetgrpfield.in_applyrule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyruledtl_code", applyruletargetgrpfield.in_applyruledtl_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyrule_basesele_code", applyruletargetgrpfield.in_applyrule_basesele_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_targetgrp_field", applyruletargetgrpfield.in_targetgrp_field, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", applyruletargetgrpfield.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", applyruletargetgrpfield.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", applyruletargetgrpfield.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tapplyrule_targetgrpfield", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Applyrule_basesele(Applyrule_basesele applyrulebasesele)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_applyrule_basesele_gid", applyrulebasesele.in_applyrule_basesele_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_applyrule_basesele_code", applyrulebasesele.in_applyrule_basesele_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyrule_code", applyrulebasesele.in_applyrule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyruledtl_code", applyrulebasesele.in_applyruledtl_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_base_acc_code", applyrulebasesele.in_base_acc_code, DbType.String));
               
                parameters.Add(dbManager.CreateParameter("in_base_acc_mode", applyrulebasesele.in_base_acc_mode, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_target_acc_code", applyrulebasesele.in_target_acc_code, DbType.String));
                
                parameters.Add(dbManager.CreateParameter("in_target_acc_mode", applyrulebasesele.in_target_acc_mode, DbType.String));
               
                parameters.Add(dbManager.CreateParameter("in_sele_order", applyrulebasesele.in_sele_order, DbType.Decimal));

                parameters.Add(dbManager.CreateParameter("in_active_status", applyrulebasesele.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", applyrulebasesele.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", applyrulebasesele.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tapplyrule_basesele", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Applyrule_basefilter(Applyrule_basefilter applyrulebasefilter)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_applyrule_basefilter_gid", applyrulebasefilter.in_applyrule_basefilter_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_applyrule_basefilter_code", applyrulebasefilter.in_applyrule_basefilter_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyrule_code", applyrulebasefilter.in_applyrule_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyruledtl_code", applyrulebasefilter.in_applyruledtl_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_applyrule_basesele_code", applyrulebasefilter.in_applyrule_basesele_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_filter_applied_on", applyrulebasefilter.in_filter_applied_on, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_filter_field", applyrulebasefilter.in_filter_field, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_filter_criteria", applyrulebasefilter.in_filter_criteria, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_add_filter", applyrulebasefilter.in_add_filter, DbType.Int16));

                parameters.Add(dbManager.CreateParameter("in_ident_criteria", applyrulebasefilter.in_ident_criteria, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_ident_value", applyrulebasefilter.in_ident_value, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", applyrulebasefilter.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", applyrulebasefilter.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", applyrulebasefilter.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tapplyrule_basefilter", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
using static ReconModels.ReconModel;
using static ReconModels.RulesetupModel;
using static ReconModels.UserManagementModel;

namespace ReconDataLayer
{
    public class RulesetupData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        DBManager dbManager = new DBManager("ConnectionString");
        List<IDbDataParameter>? parameters; 
        public DataTable Rulesetuplistdata(Rulesetuplist objrulesetuplist, UserManagementModel.headerValue headerval)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objrulesetuplist.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_recon_rule", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        

        public DataTable Rulesetupheaderdata(Rulesetupheader objrulesetupheader, UserManagementModel.headerValue headerval)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_rule_gid", objrulesetupheader.in_rule_gid, DbType.Int64, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_rule_code", objrulesetupheader.in_rule_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rule_name", objrulesetupheader.in_rule_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objrulesetupheader.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_period_from", objrulesetupheader.in_period_from, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_period_to", objrulesetupheader.in_period_to, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_rule_order", objrulesetupheader.in_rule_order, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_until_active_flag", objrulesetupheader.in_until_active_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_applyrule_on", objrulesetupheader.in_applyrule_on, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_source_dataset_code", objrulesetupheader.in_source_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_comparison_dataset_code", objrulesetupheader.in_comparison_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_source_acc_mode", objrulesetupheader.in_source_acc_mode, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_comparison_acc_mode", objrulesetupheader.in_comparison_acc_mode, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_parent_dataset_code", objrulesetupheader.in_parent_dataset_code, DbType.String));
                // parameters.Add(dbManager.CreateParameter("in_support_dataset_code", objrulesetupheader.in_support_dataset_code, DbType.String));
                // parameters.Add(dbManager.CreateParameter("in_parent_acc_mode", objrulesetupheader.in_parent_acc_mode, DbType.String));
                // parameters.Add(dbManager.CreateParameter("in_reversal_flag", objrulesetupheader.in_reversal_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_group_flag", objrulesetupheader.in_group_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objrulesetupheader.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objrulesetupheader.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", objrulesetupheader.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_trulesetup", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }



        public DataTable RulegroupingData(Rulegrouping objrulegrouping, UserManagementModel.headerValue headerval)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_rulegrpfield_gid", objrulegrouping.in_rulegrpfield_gid, DbType.Int64, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_rule_gid", objrulegrouping.in_rule_gid, DbType.Int64));
                parameters.Add(dbManager.CreateParameter("in_group_method_flag", objrulegrouping.in_group_method_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_manytomany_match_flag", objrulegrouping.in_manytomany_match_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_grp_field", objrulegrouping.in_grp_field, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rule_code", objrulegrouping.in_rule_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objrulegrouping.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objrulegrouping.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objrulegrouping.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_trulegrpfield", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        

        public DataTable RuleidentifierData(RuleIdentifier objruleidentifier, UserManagementModel.headerValue headerval)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ruleselefilter_gid", objruleidentifier.in_ruleselefilter_gid, DbType.Int64, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_rule_code", objruleidentifier.in_rule_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_filter_applied_on", objruleidentifier.in_filter_applied_on, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_filter_field", objruleidentifier.in_filter_field, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_filter_criteria", objruleidentifier.in_filter_criteria, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ident_criteria", objruleidentifier.in_ident_criteria, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ident_value", objruleidentifier.in_ident_value, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objruleidentifier.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objruleidentifier.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", objruleidentifier.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_truleselefilter", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        
        public DataTable RuleconditionData(RuleCondition objrulecondition, UserManagementModel.headerValue headerval)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_rulecondition_gid", objrulecondition.in_rulecondition_gid, DbType.Int64, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_rule_code", objrulecondition.in_rule_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_source_field", objrulecondition.in_source_field, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_comparison_field", objrulecondition.in_comparison_field, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_extraction_criteria", objrulecondition.in_extraction_criteria, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_comparison_criteria", objrulecondition.in_comparison_criteria, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objrulecondition.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objrulecondition.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objrulecondition.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_trulecondition", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public DataSet fetchRuleData(fetchRule objfetchrule, UserManagementModel.headerValue headerval)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_rule_code", objfetchrule.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedurelist("pr_fetch_ruledetails", CommandType.StoredProcedure, parameters.ToArray());
                ds.Tables[0].TableName = "RuleHeader";
                ds.Tables[1].TableName = "RuleGrouping";
                ds.Tables[2].TableName = "RuleIdentifier";
                ds.Tables[3].TableName = "RuleCondition";


                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

		public DataTable getConditionData(getCondition objcondition, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_condition_type", objcondition.in_condition_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_type", objcondition.in_field_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_condition", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}

		public DataTable getdataagainsReconData(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objdatarecon.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_datasetdetails", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}


		//getruleagainstReconData

		public DataTable getruleagainstReconData(getruleagainstRecon objRecon, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objRecon.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rule_apply_on", objRecon.in_rule_apply_on, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_ruleagainstrecon", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}


	}

}
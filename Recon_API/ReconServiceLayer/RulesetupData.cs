using Newtonsoft.Json;
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
using static ReconModels.theme_model;
using static ReconModels.UserManagementModel;

namespace ReconDataLayer
{
	public class RulesetupData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		List<IDbDataParameter>? parameters;
		public DataTable Rulesetuplistdata(Rulesetuplist objrulesetuplist, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
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
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_recon_rule" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrulesetuplist), "pr_get_recon_rule", headerval.user_code, constring);
				return result;
			}
		}



		public DataTable Rulesetupheaderdata(Rulesetupheader objrulesetupheader, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_rule_gid", objrulesetupheader.in_rule_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_rule_code", objrulesetupheader.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rule_name", objrulesetupheader.in_rule_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objrulesetupheader.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_probableflag", objrulesetupheader.probableflag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_period_from", objrulesetupheader.in_period_from, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_period_to", objrulesetupheader.in_period_to, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_rule_order", objrulesetupheader.in_rule_order, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_rule_remark", objrulesetupheader.ruleremark, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_until_active_flag", objrulesetupheader.in_until_active_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_applyrule_on", objrulesetupheader.in_applyrule_on, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_source_dataset_code", objrulesetupheader.in_source_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_dataset_code", objrulesetupheader.in_comparison_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_source_acc_mode", objrulesetupheader.in_source_acc_mode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_acc_mode", objrulesetupheader.in_comparison_acc_mode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_parent_dataset_code", objrulesetupheader.in_parent_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_parent_acc_mode", objrulesetupheader.in_parent_acc_mode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_group_flag", objrulesetupheader.in_group_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rule_automatch_partial", objrulesetupheader.in_rule_automatch_partial, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_threshold_flag", objrulesetupheader.thresholdflag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_threshold_code", objrulesetupheader.threshold_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_threshold_plus_value", objrulesetupheader.in_threshold_plus_value, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_threshold_minus_value", objrulesetupheader.in_threshold_minus_value, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_active_status", objrulesetupheader.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objrulesetupheader.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objrulesetupheader.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_inactive_reason", objrulesetupheader.in_inactive_reason, DbType.String));
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
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_trulesetup" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrulesetupheader), "pr_recon_mst_trulesetup", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable RulegroupingData(Rulegrouping objrulegrouping, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_rulegrpfield_gid", objrulegrouping.in_rulegrpfield_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_grp_field", objrulegrouping.in_grp_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rulegrpfield_seqno", objrulegrouping.rulegrpfield_seqno, DbType.Decimal));
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
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_trulegrpfield" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrulegrouping), "pr_recon_mst_trulegrpfield", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable RuleidentifierData(RuleIdentifier objruleidentifier, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_ruleselefilter_gid", objruleidentifier.in_ruleselefilter_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_rule_code", objruleidentifier.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleselefilter_seqno", objruleidentifier.ruleselefilter_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_filter_applied_on", objruleidentifier.in_filter_applied_on, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_field", objruleidentifier.in_filter_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_criteria", objruleidentifier.in_filter_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ident_criteria", objruleidentifier.in_ident_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ident_value_flag", objruleidentifier.in_ident_value_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ident_value", objruleidentifier.in_ident_value, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_flag", objruleidentifier.in_open_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_flag", objruleidentifier.in_close_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", objruleidentifier.in_join_condition, DbType.String));
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
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_truleselefilter" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objruleidentifier), "pr_recon_mst_truleselefilter", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable RuleconditionData(RuleCondition objrulecondition, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_rulecondition_gid", objrulecondition.in_rulecondition_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_rule_code", objrulecondition.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rulecondition_seqno", objrulecondition.in_rulecondition_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_source_field", objrulecondition.in_source_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_field", objrulecondition.in_comparison_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_extraction_criteria", objrulecondition.in_extraction_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_criteria", objrulecondition.in_comparison_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_flag", objrulecondition.in_open_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_flag", objrulecondition.in_close_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", objrulecondition.in_join_condition, DbType.String));
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
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_trulecondition" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrulecondition), "pr_recon_mst_trulecondition", headerval.user_code, constring);
				return result;
			}
		}
		public DataSet fetchRuleData(fetchRule objfetchrule, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_rule_gid", objfetchrule.in_rule_gid, DbType.Int16));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedurelist("pr_fetch_ruledetails", CommandType.StoredProcedure, parameters.ToArray());
				ds.Tables[0].TableName = "RuleHeader";
				ds.Tables[1].TableName = "RuleCondition";
				ds.Tables[2].TableName = "RuleGrouping";
				ds.Tables[3].TableName = "sourceidentifier";
				ds.Tables[4].TableName = "comparisionidentifier";				
				ds.Tables[5].TableName = "RulefieldorderSource";
				ds.Tables[6].TableName = "Rulefieldordercomparison";
				ds.Tables[7].TableName = "Ruleaggfunction";
				ds.Tables[8].TableName = "Ruleaggcondition";
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_fetch_ruledetails" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objfetchrule), "pr_fetch_ruledetails", headerval.user_code, constring);
				return ds;
			}
		}
		public DataTable getConditionData(getCondition objcondition, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_condition_type", objcondition.in_condition_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_type", objcondition.in_field_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objcondition.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_condition", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_condition" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objcondition), "pr_get_condition", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable getdataagainsReconData(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
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
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_datasetdetails" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatarecon), "pr_get_datasetdetails", headerval.user_code, constring);
				return result;
			}
		}
		//getruleagainstReconData
		public DataSet getruleagainstReconData(getruleagainstRecon objRecon, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objRecon.in_recon_code, DbType.String));
				ds = dbManager.execStoredProcedurelist("pr_get_ruleagainstrecon", CommandType.StoredProcedure, parameters.ToArray());
				if (ds.Tables.Count >= 2)
				{
					ds.Tables[0].TableName = "ReconRule";
					ds.Tables[1].TableName = "ReconDataSet";
				}
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_ruleagainstrecon" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objRecon), "pr_get_ruleagainstrecon", headerval.user_code, constring);
				return ds;
			}
		}

		public DataTable rulefieldorderData(Rulefieldorder objRulefieldorder, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_rulerecorder_gid", objRulefieldorder.in_rulerecorder_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_rule_code", objRulefieldorder.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recorder_applied_on", objRulefieldorder.in_recorder_applied_on, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recorder_seqno", objRulefieldorder.in_recorder_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_recorder_field", objRulefieldorder.in_recorder_field, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_active_status", objRulefieldorder.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objRulefieldorder.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objRulefieldorder.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_trulerecorder", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_trulerecorder" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objRulefieldorder), "pr_recon_mst_trulerecorder", headerval.user_code, constring);
				return result;
			}
		}

		public DataTable getReconData(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objdatarecon.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_rulerecondetails", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_rulerecondetails" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatarecon), "pr_get_rulerecondetails", headerval.user_code, constring);
				return result;
			}
		}
		
		//cloneReconRuleData
		public DataTable cloneReconRuleData(cloneReconRuleModel objcloneReconRule, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objcloneReconRule.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rule_name", objcloneReconRule.in_rule_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_source_dataset_code", objcloneReconRule.in_source_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_dataset_code", objcloneReconRule.in_comparison_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_clone_recon_code", objcloneReconRule.in_clone_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_clone_rule_code", objcloneReconRule.in_clone_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_clone_source_dataset_code", objcloneReconRule.in_clone_source_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_clone_comparison_dataset_code", objcloneReconRule.in_clone_comparison_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_clone_reconrule", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_clone_reconrule" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objcloneReconRule), "pr_clone_reconrule", headerval.user_code, constring);
				return result;
			}
		}
		//getAllRuleListData
		public DataTable getAllRuleListData(UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_allrulelist", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_allrulelist" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_allrulelist", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable ruleaggfunData(ruleAggfunction objAggfunction, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_ruleaggfield_gid", objAggfunction.ruleaggfield_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_rule_code", objAggfunction.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_field", objAggfunction.recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleaggfield_seqno", objAggfunction.ruleaggfield_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_ruleaggfield_applied_on", objAggfunction.ruleaggfield_applied_on, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleaggfield_desc", objAggfunction.ruleaggfield_desc, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleagg_function", objAggfunction.ruleagg_function, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objAggfunction.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objAggfunction.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_truleaggfun", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_truleaggfun" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objAggfunction), "pr_recon_mst_truleaggfun", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable ruleaggconditionData(ruleAggcondition objAggcondition, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_ruleaggcondition_gid", objAggcondition.ruleaggcondition_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_rule_code", objAggcondition.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleaggcondition_seqno", objAggcondition.ruleaggcondition_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_ruleagg_applied_on", objAggcondition.ruleagg_applied_on, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleagg_field", objAggcondition.ruleagg_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleagg_criteria", objAggcondition.ruleagg_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleagg_value_flag", objAggcondition.ruleagg_value_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ruleagg_value", objAggcondition.ruleagg_value, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_flag", objAggcondition.in_open_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_flag", objAggcondition.in_close_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", objAggcondition.in_join_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objAggcondition.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objAggcondition.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_truleaggcon", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_truleaggcon" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objAggcondition), "pr_recon_mst_truleaggcon", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable getConditioncriteriaruleData(getConditionrule objcondition, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_condition_type", objcondition.in_condition_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_type", objcondition.in_field_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rule_code", objcondition.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_conditionrule", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_conditionrule" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objcondition), "pr_get_conditionrule", headerval.user_code, constring);
				return result;
			}
		}
	}

}
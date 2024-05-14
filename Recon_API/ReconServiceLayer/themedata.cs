using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
using static ReconModels.ProcessModel;
using static ReconModels.ReconModel;
using static ReconModels.RulesetupModel;
using static ReconModels.theme_model;

namespace ReconDataLayer
{
	public class themedata
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();

		List<IDbDataParameter>? parameters;
		public DataTable themeReaddata(UserManagementModel.headerValue headerval, themelistmodel list, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", list.recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_themelist", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_themelist" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_themelist", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable themeHeaderdata(themeHeadermodel Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_theme_gid", Objmodel.theme_gid, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_theme_code", Objmodel.theme_Code, DbType.String, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_theme_name", Objmodel.theme_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_theme_order", Objmodel.theme_order, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_theme_type", Objmodel.theme_type, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_source_dataset", Objmodel.source_dataset, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_dataset", Objmodel.comparison_dataset, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_inactive_reason", Objmodel.inactive_reason, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", Objmodel.in_action_by, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_ttheme", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_ttheme" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_ttheme", headerval.user_code, constring);
				//objlog.logger(errorlogModel objerrorlog);
				return result;
			}
		}

		public DataTable themedetaildata(themedetailmodel Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_themefilter_gid", Objmodel.themefilter_gid, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_themefilter_seqno", Objmodel.themefilter_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_theme_code", Objmodel.theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_applied_on", Objmodel.filter_applied_on, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_field", Objmodel.filter_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_criteria", Objmodel.filter_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_value", Objmodel.filter_value, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_flag", Objmodel.open_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_flag", Objmodel.close_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", Objmodel.join_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tthemefield", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tthemefield" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_tthemefield", headerval.user_code, constring);
				return result;
			}
		}

		public DataSet themedetaildatafetch(themeDetailmodelfetch themeDetailmodel,UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_theme_code", themeDetailmodel.theme_Code, DbType.String));				
				ds = dbManager.execStoredProcedure("pr_get_themefield", CommandType.StoredProcedure, parameters.ToArray());				
				ds.Tables[0].TableName = "themeHeader";
				ds.Tables[1].TableName = "themeCondition";			
				ds.Tables[2].TableName = "sourceidentifier";
				ds.Tables[3].TableName = "comparisionidentifier";
				ds.Tables[4].TableName = "themeGrouping";
				ds.Tables[5].TableName = "Aggfunction";
				ds.Tables[6].TableName = "AggCondition";
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_themefield" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_themefield", headerval.user_code, constring);
				return ds;
			}
		}
		
		public DataTable ThemeConditionData(ThemeCondition objthemeCondition, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_themecondition_gid", objthemeCondition.in_themecondition_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_theme_code", objthemeCondition.in_theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_themecondition_seqno", objthemeCondition.in_themecondition_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_source_field", objthemeCondition.in_source_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_field", objthemeCondition.in_comparison_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_extraction_criteria", objthemeCondition.in_extraction_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_criteria", objthemeCondition.in_comparison_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_flag", objthemeCondition.in_open_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_flag", objthemeCondition.in_close_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", objthemeCondition.in_join_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objthemeCondition.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objthemeCondition.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tthemecondition", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_trulecondition" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_tthemecondition", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable themegroupingData(themegrouping objthemegrouping, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_themegrpfield_gid", objthemegrouping.in_themegrpfield_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_grp_field", objthemegrouping.in_grp_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_grpfield_seqno", objthemegrouping.themegrpfield_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_theme_code", objthemegrouping.in_theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_grpfield_applied_on", objthemegrouping.grpfield_applied_on_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objthemegrouping.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objthemegrouping.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tthemegrpfield", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tthemegrpfield" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_tthemegrpfield", headerval.user_code, constring);
				return result;
			}
		}

		public DataTable themeaggfunData(Aggfunction objAggfunction, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_themeaggfield_gid", objAggfunction.themeaggfield_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_theme_code", objAggfunction.in_theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_field", objAggfunction.recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_themeaggfield_seqno", objAggfunction.themeaggfield_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_themeaggfield_applied_on", objAggfunction.themeaggfield_applied_on, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_themeaggfield_name", objAggfunction.themeaggfield_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_themeagg_function", objAggfunction.themeagg_function, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objAggfunction.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objAggfunction.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tthemeaggfun", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tthemeaggfun" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_tthemeaggfun", headerval.user_code, constring);
				return result;
			}			
		}
		public DataTable getConditioncriteriaData(getConditiontheme objcondition, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_condition_type", objcondition.in_condition_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_type", objcondition.in_field_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_theme_code", objcondition.in_theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_conditiontheme", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_conditiontheme" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_conditiontheme", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable themeaggconditionData(Aggcondition objAggcondition, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_themeaggcondition_gid", objAggcondition.themeaggcondition_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_theme_code", objAggcondition.in_theme_code, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_themeaggcondition_seqno", objAggcondition.themeaggcondition_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_themeagg_applied_on", objAggcondition.themeagg_applied_on, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_themeagg_field", objAggcondition.themeagg_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_themeagg_criteria", objAggcondition.themeagg_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_themeagg_value_flag", objAggcondition.themeagg_value_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_themeagg_value", objAggcondition.themeagg_value, DbType.String));
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
				ds = dbManager.execStoredProcedure("pr_recon_mst_tthemeaggcon", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tthemeaggcon" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_tthemeaggcon", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable getdataagainsReconthemeData(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval, string constring)
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
				ds = dbManager.execStoredProcedure("pr_get_datasettheme", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_datasetdetails" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_datasetdetails", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable themelistclonedata(UserManagementModel.headerValue headerval, themelistmodel list, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", list.recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_themelistclone", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_themelistclone" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_themelistclone", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable clonethemeData(clonethemeModel objclonetheme, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_theme_name", objclonetheme.in_theme_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_clone_theme_code", objclonetheme.in_clone_theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_theme_code", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_clone_theme", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_clone_theme" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_clone_theme", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable runreconthemeData(runreconthemeModel objrunrecontheme, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();

				parameters.Add(dbManager.CreateParameter("in_recon_code", objrunrecontheme.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_period_from", objrunrecontheme.in_period_from, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_period_to", objrunrecontheme.in_period_to, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_automatch_flag", objrunrecontheme.in_automatch_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_run_theme", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_theme" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_run_theme", headerval.user_code, constring);
				throw ex;
			}

		}
	}
}

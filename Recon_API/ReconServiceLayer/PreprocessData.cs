using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.PreprocessModel;
using static ReconModels.ReconModel;
using static ReconModels.RulesetupModel;
using static ReconModels.theme_model;

namespace ReconDataLayer
{
    public class PreprocessData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter>? parameters;

        public DataTable getPreprocessListData(Preprocesslistmodel objpreprocess, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objpreprocess.recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_preprocesslist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_preprocesslist" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objpreprocess), "pr_get_preprocesslist", headerval.user_code, constring);
				return result;
            }
        }
		public DataTable preprocessHeaderdata(preprocessHeadermodel Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocess_gid", Objmodel.preprocess_gid, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", Objmodel.preprocess_Code, DbType.String, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_desc", Objmodel.preprocess_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_get_recon_field", Objmodel.get_recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_set_recon_field", Objmodel.set_recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_process_method", Objmodel.process_method, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_process_query", Objmodel.process_query, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_expression", Objmodel.expression, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_process_function", Objmodel.process_function, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lookup_dataset_code", Objmodel.lookup_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lookup_multi_return_flag", Objmodel.lookup_multi_return_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lookup_return_field", Objmodel.lookup_return_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_preprocess_order", Objmodel.preprocess_order, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_hold_flag", Objmodel.hold_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_returnflag", Objmodel.in_returnflag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_postprocessflag", Objmodel.postprocessflag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_cumulative_flag", Objmodel.in_cumulative_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", Objmodel.in_action_by, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tpreprocess", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tpreprocess" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_recon_mst_tpreprocess", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable preprocessfilterData(filterdata objfilterdata, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocessfilter_gid", objfilterdata.in_preprocessfilter_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", objfilterdata.in_preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objfilterdata.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_seqno", objfilterdata.in_filter_seqno, DbType.Double));
				parameters.Add(dbManager.CreateParameter("in_filter_applied_on", objfilterdata.in_filter_applied_on, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_filter_field", objfilterdata.in_filter_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_criteria", objfilterdata.in_filter_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_value_flag", objfilterdata.in_ident_value_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_value", objfilterdata.in_ident_value, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_flag", objfilterdata.in_open_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_flag", objfilterdata.in_close_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", objfilterdata.in_join_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objfilterdata.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objfilterdata.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objfilterdata.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tpreprocessfilter", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tpreprocessfilter" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objfilterdata), "pr_recon_mst_tpreprocessfilter", headerval.user_code, constring);
				return result;
			}
		}
		public DataSet getPreprocessfetchData(Preprocessfetchmodel objpreprocessfetch, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", objpreprocessfetch.preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_preprocessfetch", CommandType.StoredProcedure, parameters.ToArray());
				ds.Tables[0].TableName = "header";
				ds.Tables[1].TableName = "filter";
				ds.Tables[2].TableName = "condition";
				ds.Tables[3].TableName = "lookup";
				ds.Tables[4].TableName = "filterlookup";
				ds.Tables[5].TableName = "conditionlookup";
				ds.Tables[6].TableName = "preprocessorder";
				ds.Tables[7].TableName = "aggexp";
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_preprocessfetch" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objpreprocessfetch), "pr_get_preprocessfetch", headerval.user_code, constring);
				return ds;
			}
		}
		public DataTable preprocessconditionData(conditiondata objconditiondata, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocesscondition_gid", objconditiondata.in_preprocesscondition_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", objconditiondata.in_preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_Ldataset_code", objconditiondata.in_Ldataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_Lreturn_field", objconditiondata.in_Lreturn_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_setrecon_field", objconditiondata.in_setrecon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_condition_seqno", objconditiondata.in_condition_seqno, DbType.Double));
				parameters.Add(dbManager.CreateParameter("in_recon_field", objconditiondata.in_recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_extraction_criteria", objconditiondata.in_extraction_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_extraction_filter", objconditiondata.in_extraction_filter, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lookup_field", objconditiondata.in_lookup_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_criteria", objconditiondata.in_comparison_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_comparison_filter", objconditiondata.in_comparison_filter, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_flag", objconditiondata.in_open_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_flag", objconditiondata.in_close_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", objconditiondata.in_join_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_source_field_type", objconditiondata.in_source_field_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_returnflag", objconditiondata.in_returnflag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objconditiondata.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objconditiondata.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tpreprocesscondition", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tpreprocesscondition" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objconditiondata), "pr_recon_mst_tpreprocesscondition", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable ValidatequeryData(Validatequerymodel objValidatequerymodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_sql", objValidatequerymodel.in_sql, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_run_sql", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[name: "outparam"];
				//result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_sql" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objValidatequerymodel), "pr_run_sql", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable getConditionlookupData(getConditionlook objcondition, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_condition_type", objcondition.in_condition_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_type", objcondition.in_field_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_dataset_code", objcondition.in_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_conditionlookup", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_conditionlookup" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objcondition), "pr_get_conditionlookup", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable getPreprocessListclonedata(Preprocesslistmodelclone objpreprocess, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objpreprocess.recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_preprocesslistclone", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_preprocesslistclone" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objpreprocess), "pr_get_preprocesslistclone", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable clonepreprocessData(clonepreprocessModel objclonepreprocess, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();				
				parameters.Add(dbManager.CreateParameter("in_preprocess_name", objclonepreprocess.in_preprocess_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_clone_preprocess_code", objclonepreprocess.in_clone_preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_preprocess_code", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_clone_preprocess", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_clone_preprocess" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objclonepreprocess), "pr_clone_preprocess", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable getdatasetReconPreprocessdata(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval, string constring)
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
				ds = dbManager.execStoredProcedure("pr_get_datasetpreprocess", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_datasetpreprocess" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatarecon), "pr_get_datasetpreprocess", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable lookupfieldsavedata(lookupfieldmodel objdatarecon, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocesslookup_gid", objdatarecon.in_preprocesslookup_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", objdatarecon.in_preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_setrecon_field", objdatarecon.in_set_recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lookup_seqno", objdatarecon.in_lookup_seqno, DbType.Double));
				parameters.Add(dbManager.CreateParameter("in_lookup_return_field", objdatarecon.in_lookup_return_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_set_recon_field", objdatarecon.in_set_recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objdatarecon.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objdatarecon.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tpreprocesslookup", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_datasetpreprocess" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatarecon), "pr_get_datasetpreprocess", headerval.user_code, constring);
				return result;
			}
		}

		public DataTable reconfieldorderData(reconfieldorder objreconfieldorder, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocessrecorder_gid", objreconfieldorder.in_preprocessrecorder_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", objreconfieldorder.in_preprocess_code, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_recorder_seqno", objreconfieldorder.in_recorder_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_recorder_field", objreconfieldorder.in_recorder_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objreconfieldorder.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objreconfieldorder.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objreconfieldorder.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tpreprocessrecorder", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tpreprocessrecorder" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreconfieldorder), "pr_recon_mst_trulerecorder", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable AggExpressionData(aggexpmodel objaggexpmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocessgrpfield_gid", objaggexpmodel.in_preprocessgrpfield_gid, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", objaggexpmodel.in_preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_grpfield_seqno", objaggexpmodel.in_grpfield_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_grp_field", objaggexpmodel.in_grp_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objaggexpmodel.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objaggexpmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objaggexpmodel.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tpreprocessagg", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tpreprocessrecorder" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objaggexpmodel), "pr_recon_mst_trulerecorder", headerval.user_code, constring);
				return result;
			}
		}
	}
}

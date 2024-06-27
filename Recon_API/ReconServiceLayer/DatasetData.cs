using ReconModels;
using System.Data;
using static ReconModels.CommonModel;
using static ReconModels.DatasetModel;
using static ReconModels.CommonModel;
using ReconDataLayer;
using static ReconModels.UserManagementModel;

namespace ReconDataLayer
{
    public class DatasetData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		
		List<IDbDataParameter>? parameters;
		public DataTable DatasetReaddata(Datasetlistmodel Objmodel, UserManagementModel.headerValue headerval,string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();			
				parameters.Add(dbManager.CreateParameter("in_user_gid", Objmodel.in_user_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));				
				ds = dbManager.execStoredProcedure("pr_get_Dataset", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_Dataset" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_Dataset", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable DatasetHeaderdata(DatasetHeadermodel  Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();			
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_dataset_gid", Objmodel.dataset_id, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_dataset_code", Objmodel.datasetCode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_dataset_name", Objmodel.dataset_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_dataset_category", Objmodel.dataset_category, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_clone_dataset", Objmodel.clone_dataset, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_reason", Objmodel.inactive_reason, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tdataset", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tdataset"+"Error Message:" + ex.Message );
				//objlog.logger(errorlogModel objerrorlog);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_tdataset", headerval.user_code, constring);
				return result;
			}
		}
		public DataTable DatasetDetaildata(Datasetdetailmodel Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_datasetfield_gid", Objmodel.datasetdetail_id, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_dataset_code", Objmodel.datasetCode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_name", Objmodel.field_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_type", Objmodel.field_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_length", Objmodel.field_length, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_precision_length", Objmodel.precision_length, DbType.Int64));
				parameters.Add(dbManager.CreateParameter("in_scale_length", Objmodel.scale_length, DbType.Int64));
				parameters.Add(dbManager.CreateParameter("in_field_mandatory", Objmodel.field_mandatory, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tdatasetfield", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tdatasetfield"+"Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_tdatasetfield", headerval.user_code, constring);
				return result;
			}
		}
		public DataSet DatasetReaddetaildata(Datasetdetailmodellist Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();			
				parameters.Add(dbManager.CreateParameter("in_dataset_gid", Objmodel.dataset_gid, DbType.Int16));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_Datasetdetail", CommandType.StoredProcedure, parameters.ToArray());
				if (ds.Tables.Count >= 2)
				{
					ds.Tables[0].TableName = "Header";
					ds.Tables[1].TableName = "DataSet";
				}
				return ds;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_Datasetdetail"+"Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_Datasetdetail", headerval.user_code, constring);
				return ds;
			}
		}
		public DataTable getfieldtype(UserManagementModel.headerValue headerval,string constring)
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
				ds = dbManager.execStoredProcedure("pr_get_fieldtype", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_fieldtype"+"Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_fieldtype", headerval.user_code, constring);
				return result;
			}
		}


        public DataTable cloneDatasetdata(clonedataset objclonedataset, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_clone_dataset_code", objclonedataset.in_clone_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_new_dataset_code", objclonedataset.in_new_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", objclonedataset.in_action_by, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_dataset_clone", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_dataset_clone"+"Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_recon_mst_dataset_clone", objclonedataset.in_action_by, constring);
				return result;
            }
        }

		//getSchedulerData
		public DataTable getSchedulerData(getSchedulerModel objgetScheduler, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_processed_date", objgetScheduler.in_processed_date, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_scheduler_status", objgetScheduler.in_scheduler_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_get_scheduler", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_scheduler" + " "+ "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_scheduler", headerval.user_code, constring);
				return result;
			}
		}

		//delSchedulerData

		public DataTable delSchedulerData(delSchedulerModel objdelScheduler, UserManagementModel.headerValue headerval , string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_scheduler_gid", objdelScheduler.in_scheduler_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_remark", objdelScheduler.in_remark, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_del_scheduler", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_del_scheduler" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_del_scheduler", headerval.user_code, constring);
				return result;
			}
		}

        //datasetAgainstReconData
        public DataTable datasetAgainstReconData(datasetAgainstReconModel objdatasetAgainstRecon, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objdatasetAgainstRecon.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_datasetagainstrecon", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_datasetagainstrecon" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_datasetagainstrecon", headerval.user_code, constring);
				return result;
            }
        }
		//datasethistoryData
		public DataTable datasethistoryData(datasethistoryModel objdatasethistory, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_dataset_code", objdatasethistory.in_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_datasethistory", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_datasethistory" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_datasethistory", headerval.user_code, constring);
				return result;
			}
		}
	}
}

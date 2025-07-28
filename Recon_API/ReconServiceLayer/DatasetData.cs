using ReconModels;
using System.Data;
using static ReconModels.CommonModel;
using static ReconModels.DatasetModel;
using static ReconModels.CommonModel;
using ReconDataLayer;
using static ReconModels.UserManagementModel;
using Newtonsoft.Json;

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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_get_Dataset", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_recon_mst_tdataset", headerval.user_code, constring);
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
                parameters.Add(dbManager.CreateParameter("in_seq_no", Objmodel.seq_no, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_field_mandatory", Objmodel.field_mandatory, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tdatasetfieldnew", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tdatasetfield"+"Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_recon_mst_tdatasetfield", headerval.user_code, constring);
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
				if (ds.Tables.Count >= 3)
				{
					ds.Tables[0].TableName = "Header";
					ds.Tables[1].TableName = "DataSet";
                    ds.Tables[2].TableName = "DataSetindex";
                }
				return ds;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_Datasetdetail"+"Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_get_Datasetdetail", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_fieldtype", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objclonedataset), "pr_recon_mst_dataset_clone", objclonedataset.in_action_by, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgetScheduler), "pr_get_scheduler", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdelScheduler), "pr_del_scheduler", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatasetAgainstRecon), "pr_get_datasetagainstrecon", headerval.user_code, constring);
				return result;
            }
        }

		//getaccbaldatasetData
		public DataTable getaccbaldatasetData(getaccbaldatasetModel objgetaccbaldataset, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_dataset_code", objgetaccbaldataset.in_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_accbaldataset", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_accbaldataset" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgetaccbaldataset), "pr_get_accbaldataset", headerval.user_code, constring);
				return result;
			}
		}

		//setAccountbalanceData

		public DataTable setAccountbalanceData(setAccountbalanceModel objsetAccountbalance, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_accbal_gid", objsetAccountbalance.in_accbal_gid, DbType.Int16,ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_dataset_code", objsetAccountbalance.in_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_tran_date", objsetAccountbalance.in_tran_date, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_bal_value", objsetAccountbalance.in_bal_value, DbType.Double));
				parameters.Add(dbManager.CreateParameter("in_action", objsetAccountbalance.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_set_recon_trn_taccbal", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_set_recon_trn_taccbal" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objsetAccountbalance), "pr_set_recon_trn_taccbal", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatasethistory), "pr_get_datasethistory", headerval.user_code, constring);
				return result;
			}
		}

        public DataTable Datasetindexdata(Datasetindexmodel Objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_datasetindex_gid", Objmodel.in_datasetindex_gid, DbType.Int64, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_dataset_code", Objmodel.in_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_datasetindex_code", Objmodel.in_datasetindex_code, DbType.String));               
                parameters.Add(dbManager.CreateParameter("in_index_seqno", Objmodel.in_index_seqno, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_index_desc", Objmodel.in_index_desc, DbType.String));                              
                parameters.Add(dbManager.CreateParameter("in_dataset_field", Objmodel.in_dataset_field, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_tdatasetindex", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_tdatasetindex" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_recon_mst_tdatasetindex", headerval.user_code, constring);
                return result;
            }
        }
        public DataTable Datasetindexlistdata(Datasetindexlist Objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_datasetindex_code", Objmodel.in_datasetindex_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", Objmodel.in_user_code, DbType.String));               
                ds = dbManager.execStoredProcedure("pr_get_tdatasetindex", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_tdatasetindex" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_tdatasetindex", headerval.user_code, constring);
                return result;
            }
        }
    }
}

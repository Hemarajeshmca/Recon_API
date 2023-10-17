using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;

namespace ReconDataLayer
{
	public class DatasetData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter>? parameters;
		public DataTable DatasetReaddata(Datasetlistmodel Objmodel)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();			
				parameters.Add(dbManager.CreateParameter("in_user_gid", Objmodel.in_user_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.in_active_status, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_Dataset", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}
		public DataTable DatasetHeaderdata(DatasetHeadermodel  Objmodel)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();			
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_dataset_gid", Objmodel.dataset_id, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_dataset_code", Objmodel.datasetCode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_dataset_name", Objmodel.dataset_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_dataset_category", Objmodel.dataset_category, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", Objmodel.in_action_by, DbType.String));				
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tdataset", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}
		public DataTable DatasetDetaildata(Datasetdetailmodel Objmodel)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_datasetfield_gid", Objmodel.datasetdetail_id, DbType.Int64, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_dataset_code", Objmodel.datasetCode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_name", Objmodel.field_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_type", Objmodel.field_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_length", Objmodel.field_length, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_field_mandatory", Objmodel.field_mandatory, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", Objmodel.in_action_by, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tdatasetfield", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}
		public DataTable DatasetReaddetaildata(Datasetdetailmodellist Objmodel)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();			
				parameters.Add(dbManager.CreateParameter("in_dataset_code", Objmodel.datasetCode, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_Datasetdetail", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}
		public DataTable getfieldtype()
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", "", DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_fieldtype", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}


        public DataTable cloneDatasetdata(clonedataset objclonedataset)
        {
            try
            {
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
                return result;
            }
        }

    }
}

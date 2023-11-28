using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
using static ReconModels.DatasettoReconmodel;

namespace ReconDataLayer
{
	public class DatasettoRecondata
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter>? parameters;
		public DataTable DatasettoReconReaddata(DatasettoReconmodellist Objmodel, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_gid", Objmodel.in_user_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_datasettorecon", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}
		public DataTable DatasettoReconprocessdata(DatasettoReconmodelprocess Objmodel, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_gid", Objmodel.in_user_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_scheduler_gid", Objmodel.in_user_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_datasettoreconprocess", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}


		public DataTable DatasettoManualReaddata(UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_datasettomanual", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}

        public DataSet ManuaMatchInfodata(ManualMatchinfoModel objManualMatchinfo, UserManagementModel.headerValue headerval)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_scheduler_gid", objManualMatchinfo.in_scheduler_gid, DbType.Int32));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedurelist("pr_get_manualinfo", CommandType.StoredProcedure, parameters.ToArray());
                if (ds.Tables.Count >= 3)
                {
                    ds.Tables[0].TableName = "DataSet1";
                    ds.Tables[1].TableName = "DataSet2";
                    ds.Tables[2].TableName = "DataSet3";
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }


        public DataTable runManualfiledata(runManualfileModel objrunManualfile, UserManagementModel.headerValue headerval)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_scheduler_gid", objrunManualfile.in_scheduler_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objrunManualfile.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_run_manualfile", CommandType.StoredProcedure, parameters.ToArray());
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

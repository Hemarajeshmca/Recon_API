using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.UtilityModel;

namespace ReconDataLayer
{
	public class UtilityData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter>? parameters;

		public DataTable jobstatusData(JobStatusList objobstatus, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_start_date", objobstatus.in_start_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_end_date", objobstatus.in_end_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_jobtype_code", objobstatus.in_jobtype_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_jobstatus", objobstatus.in_jobstatus, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_jobstatus", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_jobstatus" + "Error Message:" + ex.Message);
                return result;
			}
		}
		

		public DataTable jobtypeData(UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_recon_jobtype", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_recon_jobtype" + "Error Message:" + ex.Message);
                return result;
			}
		}

		public DataTable objJobCompletedData(JobCompleted objJobCompleted, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_start_date", objJobCompleted.in_start_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_end_date", objJobCompleted.in_end_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_jobtype_code", objJobCompleted.in_jobtype_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_jobcompleted", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_jobcompleted" + "Error Message:" + ex.Message);
                return result;
			}
		}

		public DataTable jobinpogressData(JobCompleted objJobCompleted, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_start_date", objJobCompleted.in_start_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_end_date", objJobCompleted.in_end_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_jobtype_code", objJobCompleted.in_jobtype_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_jobinProgress", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_jobinProgress" + "Error Message:" + ex.Message);
                return result;
			}
		}
	}
}

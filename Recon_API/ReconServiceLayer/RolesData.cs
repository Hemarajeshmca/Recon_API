using Newtonsoft.Json;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.CommonModel;
using static ReconModels.DatasetModel;
using static ReconModels.RolesModel;

namespace ReconDataLayer
{
	public class RolesData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		List<IDbDataParameter>? parameters;
		string constring1 = "";

		public DataTable rolelistData(rolelistModel objrolelist, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_role_gid", objrolelist.in_role_gid, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_role_code", objrolelist.in_role_code, DbType.String, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_role_name", objrolelist.in_role_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objrolelist.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_reason", objrolelist.in_active_reason, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objrolelist.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_admin_mst_trole", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_admin_mst_trole" + "Error Message:" + ex.Message);
				return result;
			}
		}

		//roleData
		public DataTable roleData(UserManagementModel.headerValue headerval, string constring)
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
				ds = dbManager.execStoredProcedure("pr_get_rolelist", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_rolelist" + "Error Message:" + ex.Message);
				return result;
			}
		}


		//RolefetchData

		public DataTable RolefetchData(RolefetchModel objRolefetchModel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", objRolefetchModel.in_role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_fetch_roleaccess", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_fetch_roleaccess" + "Error Message:" + ex.Message);
				return result;
			}
		}

		//RoledetailsData

		public DataTable RoledetailsData(roledetailsModel objroledetailsModel, UserManagementModel.headerValue headerval, string constring)
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
				parameters.Add(dbManager.CreateParameter("in_role_gid", objroledetailsModel.in_role_gid, DbType.Int32));
				ds = dbManager.execStoredProcedure("pr_fetch_roledetails", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_fetch_roledetails" + "Error Message:" + ex.Message);
				return result;
			}
		}

		//saveRoleAccessData

		public DataTable saveRoleAccessData(saveRoleAccessModel objsaveRoleAccessModel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DataTable JsonData = new DataTable();
				saveRoleAccessModellist objList = new saveRoleAccessModellist();
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				//var data = "[\r\n    {\r\n        \"in_role_gid\": 4,\r\n        \"in_role_code\": \"RC002\",\r\n        \"in_menu_code\": \"12\",\r\n        \"in_add_flag\": \"y\",\r\n        \"in_modify_flag\": \"y\",\r\n        \"in_view_flag\": \"y\",\r\n        \"in_download_flag\": \"y\",\r\n        \"in_deny_flag\": \"y\",\r\n        \"in_active_status\": \"y\",\r\n        \"in_delete_flag\": \"y\",\r\n        \"in_action_by\": \"Hema\"\r\n    },\r\n    {\r\n        \"in_role_gid\": 5,\r\n        \"in_role_code\": \"RC003\",\r\n        \"in_menu_code\": \"12\",\r\n        \"in_add_flag\": \"y\",\r\n        \"in_modify_flag\": \"y\",\r\n        \"in_view_flag\": \"y\",\r\n        \"in_download_flag\": \"y\",\r\n        \"in_deny_flag\": \"y\",\r\n        \"in_active_status\": \"y\",\r\n        \"in_delete_flag\": \"y\",\r\n        \"in_action_by\": \"Hema\"\r\n    }\r\n]";
				JsonData = JsonConvert.DeserializeObject<DataTable>(objsaveRoleAccessModel.roledetails);
				for (int i = 0; i < JsonData.Rows.Count; i++)
				{
					parameters = new List<IDbDataParameter>();
					parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
					parameters.Add(dbManager.CreateParameter("in_rolerights_gid", Convert.ToInt32(JsonData.Rows[i]["in_role_gid"]), DbType.Int32));
					parameters.Add(dbManager.CreateParameter("in_role_code", JsonData.Rows[i]["in_role_code"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_menu_code", JsonData.Rows[i]["in_menu_code"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_add_flag", JsonData.Rows[i]["in_add_flag"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_modify_flag", JsonData.Rows[i]["in_modify_flag"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_view_flag", JsonData.Rows[i]["in_view_flag"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_download_flag", JsonData.Rows[i]["in_download_flag"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_deny_flag", JsonData.Rows[i]["in_deny_flag"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_active_status", JsonData.Rows[i]["in_active_status"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_delete_flag", JsonData.Rows[i]["in_delete_flag"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_action_by", headerval.role_code, DbType.String));
					parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
					parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
					ds = dbManager.execStoredProcedure("pr_admin_mst_trolerights", CommandType.StoredProcedure, parameters.ToArray());
					result = ds.Tables[0];
				}
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_admin_mst_trolerights" + "Error Message:" + ex.Message);
				return result;
			}
		}
	}
}

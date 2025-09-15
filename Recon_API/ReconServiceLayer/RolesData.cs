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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrolelist), "pr_admin_mst_trole", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_rolelist", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objRolefetchModel), "pr_fetch_roleaccess", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objroledetailsModel), "pr_fetch_roledetails", headerval.user_code, constring);
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
					parameters.Add(dbManager.CreateParameter("in_deleteflag", JsonData.Rows[i]["in_deleteflag"], DbType.String));
					parameters.Add(dbManager.CreateParameter("in_process_flag", JsonData.Rows[i]["in_process_flag"], DbType.String));
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objsaveRoleAccessModel), "pr_admin_mst_trolerights", headerval.user_code, constring);
				return result;
			}
		}
        //saveRolePermissionsAccessData Pandiaraj 19-08-2025
        public DataTable saveRolePermissionsAccessData(saveRoleAccessModel objsaveRoleAccessModel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DataTable JsonData = new DataTable();
                saveRolePermissionlist model = new saveRolePermissionlist();
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                RolesData objDS = new RolesData();
                JsonData = JsonConvert.DeserializeObject<DataTable>(objsaveRoleAccessModel.roledetails);
                for (int i = 0; i < JsonData.Rows.Count; i++)
                {
                    parameters = new List<IDbDataParameter>(); parameters.Add(dbManager.CreateParameter("in_action_status", "Insert", DbType.String));
                    parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code ?? string.Empty, DbType.String));
                    parameters.Add(dbManager.CreateParameter("in_RoleReportPermission_gid", 0, DbType.Int32));
                    parameters.Add(dbManager.CreateParameter("in_role_code", JsonData.Rows[i]["in_role_code"] == DBNull.Value ? "" : Convert.ToString(JsonData.Rows[i]["in_role_code"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_recon_code", JsonData.Rows[i]["in_recon_code"] == DBNull.Value ? "" : Convert.ToString(JsonData.Rows[i]["in_recon_code"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_Recon_name", JsonData.Rows[i]["in_Recon_name"] == DBNull.Value ? "" : Convert.ToString(JsonData.Rows[i]["in_Recon_name"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_report_code", JsonData.Rows[i]["in_report_code"] == DBNull.Value ? "" : Convert.ToString(JsonData.Rows[i]["in_report_code"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_report_desc", JsonData.Rows[i]["in_report_desc"] == DBNull.Value ? "" : Convert.ToString(JsonData.Rows[i]["in_report_desc"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", JsonData.Rows[i]["in_reporttemplate_code"] == DBNull.Value ? "" : Convert.ToString(JsonData.Rows[i]["in_reporttemplate_code"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_reporttemplate_name", JsonData.Rows[i]["in_reporttemplate_name"] == DBNull.Value ? "" : Convert.ToString(JsonData.Rows[i]["in_reporttemplate_name"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_CSVDownload", JsonData.Rows[i]["in_CSVDownload_flag"] == DBNull.Value ? "N" : Convert.ToString(JsonData.Rows[i]["in_CSVDownload_flag"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_ExcelDownload", JsonData.Rows[i]["in_ExcelDownload_flag"] == DBNull.Value ? "N" : Convert.ToString(JsonData.Rows[i]["in_ExcelDownload_flag"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_Preview", JsonData.Rows[i]["in_Preview_flag"] == DBNull.Value ? "N" : Convert.ToString(JsonData.Rows[i]["in_Preview_flag"]), DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_Deny", JsonData.Rows[i]["in_deny_flag"] == DBNull.Value ? "N" : Convert.ToString(JsonData.Rows[i]["in_deny_flag"]), DbType.String));


                    parameters.Add(dbManager.CreateParameter("in_deleteflag", "N", DbType.String));
                    //parameters.Add(dbManager.CreateParameter("in_active_status","Y", DbType.String));
                    parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));

                    parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                    parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.Int32, ParameterDirection.Output));

                    ds = dbManager.execStoredProcedure("pr_admin_mst_tRoleReportPermissions", CommandType.StoredProcedure, parameters.ToArray());
                    result = ds.Tables[0];
                }
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_admin_mst_tRoleReportPermissions" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objsaveRoleAccessModel), "pr_admin_mst_trolerights", headerval.user_code, constring);
                return result;
            }
        }

        public DataTable DeleteRolePermissionsAccessData(saveRoleAccessModel objsaveRoleAccessModel, string constring)
        {
            try
            {
                DataTable JsonData = new DataTable();
                saveRolePermissionlist model = new saveRolePermissionlist();
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                JsonData = JsonConvert.DeserializeObject<DataTable>(objsaveRoleAccessModel.roledetails);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_action_status", "Delete", DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", "", DbType.String));
                parameters.Add(dbManager.CreateParameter("in_RoleReportPermission_gid", Convert.ToInt32(JsonData.Rows[0]["in_RoleReportPermission_gid"]), DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_role_code", Convert.ToString(JsonData.Rows[0]["in_role_code"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(JsonData.Rows[0]["in_recon_code"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_Recon_name", Convert.ToString(JsonData.Rows[0]["in_Recon_name"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_code", Convert.ToString(JsonData.Rows[0]["in_report_code"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_desc", Convert.ToString(JsonData.Rows[0]["in_report_desc"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", Convert.ToString(JsonData.Rows[0]["in_reporttemplate_code"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_reporttemplate_name", Convert.ToString(JsonData.Rows[0]["in_reporttemplate_name"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_CSVDownload", Convert.ToString(JsonData.Rows[0]["in_CSVDownload_flag"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ExcelDownload", Convert.ToString(JsonData.Rows[0]["in_ExcelDownload_flag"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_Preview", Convert.ToString(JsonData.Rows[0]["in_Preview_flag"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_Deny", Convert.ToString(JsonData.Rows[0]["in_deny_flag"]), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_deleteflag", "N", DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", "", DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.Int32, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_admin_mst_tRoleReportPermissions", CommandType.StoredProcedure, parameters.ToArray());

                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_admin_mst_tRoleReportPermissions" + "Error Delete Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objsaveRoleAccessModel), "pr_admin_mst_tRoleReportPermissions", "", constring);
                return result;
            }
        }
    }
}

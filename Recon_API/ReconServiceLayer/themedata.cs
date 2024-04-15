using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
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
				parameters.Add(dbManager.CreateParameter("in_hold_flag", Objmodel.holdflag, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_clone_theme", Objmodel.clone_theme, DbType.String));
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
				objlog.logger(errorlogModel objerrorlog);
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
				parameters.Add(dbManager.CreateParameter("in_theme_seqno", Objmodel.theme_seqno, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_theme_code", Objmodel.theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_field", Objmodel.recon_field, DbType.String));
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

		public DataSet themedetaildata(themeDetailmodel themeDetailmodel,UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_theme_code", themeDetailmodel.theme_Code, DbType.String));				
				ds = dbManager.execStoredProcedure("pr_get_themefield", CommandType.StoredProcedure, parameters.ToArray());
				ds.Tables[0].TableName = "themedetail";
				
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
		public DataTable Themeclonefetchdata(UserManagementModel.headerValue headerval,string constring)
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
				ds = dbManager.execStoredProcedure("pr_get_themeclonelist", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_themeclonelist" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_get_themeclonelist", headerval.user_code, constring);
				return result;
			}
		}
	}
}

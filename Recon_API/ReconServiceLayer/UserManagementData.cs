﻿using Org.BouncyCastle.Asn1.Ocsp;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.UserManagementModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ReconDataLayer
{
    public class UserManagementData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        DataSet DS = new DataSet();
        List<IDbDataParameter> parameters;
        public DataTable Loginvalidation(Login_model Objmodel, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("ConnectionStrings");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", Objmodel.user_id, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_password", Objmodel.password, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", Objmodel.ip, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_loginvalidation_new", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_loginvalidation_new" + "Error Message:" + ex.Message);
                return result;
            }
        }

        public DataTable changepass_save(change_password Usermodel, headerValue hv, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess(Usermodel.user_id);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_gid", hv.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_old_password", Usermodel.old_password, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_new_password", Usermodel.new_password, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_set_password", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_set_password" + "Error Message:" + ex.Message);
                throw ex;
            }
        }

        //dashboardData

        public DataSet dashboardData(dashboardmodel objdashboard, headerValue hv, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objdashboard.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_period_from", objdashboard.in_period_from, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_period_to", objdashboard.in_period_to, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", hv.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                DS = dbManager.execStoredProcedurelist("pr_get_dashboard", CommandType.StoredProcedure, parameters.ToArray());
                if (DS.Tables.Count >= 3)
                {
                    DS.Tables[0].TableName = "DataSet1";
                    DS.Tables[1].TableName = "DataSet2";
                    DS.Tables[2].TableName = "DataSet3";
                }
                return DS;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_dashboard" + " "+ "Error Message:" + ex.Message);
                throw ex;
            }
        }
		public DataTable userlist_db(headerValue Objmodel, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("ConnectionStrings");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", Objmodel.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", Objmodel.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", Objmodel.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_fetch_userlist", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_loginvalidation_new" + "Error Message:" + ex.Message);
				return result;
			}
		}
		public List<treeviewllist> treeviewlist_db(headerValue Objmodel, string constring)
		{
			List<treeviewllist> objList = new List<treeviewllist>();
			try
			{				
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("ConnectionStrings");
				parameters = new List<IDbDataParameter>();				
				ds = dbManager.execStoredProcedure("GetTreeNodes", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				foreach (DataRow datarow in result.Rows)
				{
					if (datarow["unitDependCode"].ToString() == "-")
					{
						treeviewllist node = new treeviewllist();
						node.parent_code = datarow["parent_code"].ToString();
						node.master_code = datarow["master_code"].ToString();
						node.master_name = datarow["master_name"].ToString();
						node.depend_code = datarow["depend_code"].ToString();
						node.id = "";
						var v_master_code = node.master_code;

						var rows = result.AsEnumerable()
									   .Where(r => r.Field<string>("depend_code") == v_master_code);

						foreach (DataRow _row in rows)
						{
							treeviewllist child1 = new treeviewllist();
							child1 = add_node(result, _row);
							node.items.Add(child1);
						}
						objList.Add(node);
					}
				}
				return objList;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:GetTreeNodes" + "Error Message:" + ex.Message);
				return objList;
			}
		}
		public treeviewllist add_node(DataTable _dt, DataRow _dr)
		{
			treeviewllist node = new treeviewllist();
			try
			{
				node.id = _dr["id"].ToString();
				node.parent_code = _dr["parent_code"].ToString();
				node.master_code = _dr["master_code"].ToString();
				node.master_name = _dr["master_name"].ToString();
				node.depend_code = _dr["depend_code"].ToString();

				var rows = _dt.AsEnumerable()
							   .Where(r => r.Field<string>("depend_code") == node.master_code);

				foreach (DataRow _row in rows)
				{
					treeviewllist child1 = new treeviewllist();
					child1 = add_node(_dt, _row);
					node.items.Add(child1);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return node;
		}
		public DataTable Usersave_db(User_model Usermodel, headerValue hv, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_gid", Usermodel.user_gid, DbType.Int16, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_user_code", Usermodel.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_name", Usermodel.user_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_contactno", Usermodel.user_contact_no, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_emailid", Usermodel.user_emailid, DbType.String));
				parameters.Add(dbManager.CreateParameter("user_password", Usermodel.user_password, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_gid", Usermodel.role_gid, DbType.Int16));
				parameters.Add(dbManager.CreateParameter("in_action_by", Usermodel.action_by, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_ins_user", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_ins_user" + "Error Message:" + ex.Message);
				throw ex;
			}
		}

		public DataTable Usermappingsave_db(usermappingmodel Usermodel, headerValue hv, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_gid", Usermodel.user_gid, DbType.Int16));
				parameters.Add(dbManager.CreateParameter("in_user_code", Usermodel.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_level_mapping", Usermodel.level_mapping, DbType.String));				
				parameters.Add(dbManager.CreateParameter("in_action_by", hv.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_ins_userlevelmapping", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_ins_userlevelmapping" + "Error Message:" + ex.Message);
				throw ex;
			}
		}
		public DataTable getcheckednode_db(getcheckedmodel Usermodel, headerValue hv, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_gid", Usermodel.user_gid, DbType.Int16));
				parameters.Add(dbManager.CreateParameter("in_user_code", Usermodel.user_code, DbType.String));				
				ds = dbManager.execStoredProcedure("pr_get_checkedvalues", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_checkedvalues" + "Error Message:" + ex.Message);
				throw ex;
			}
		}
		public DataTable setcontextlist_db(getcheckedmodel Usermodel, headerValue Objmodel, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("ConnectionStrings");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_gid", Usermodel.user_gid, DbType.Int16));
				parameters.Add(dbManager.CreateParameter("in_user_code", Usermodel.user_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_headers", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_headers" + "Error Message:" + ex.Message);
				return result;
			}
		}
	}
}

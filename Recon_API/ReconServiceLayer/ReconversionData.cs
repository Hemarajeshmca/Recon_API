﻿using DocumentFormat.OpenXml.Drawing;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasettoReconmodel;
using static ReconModels.ReconVersionmodel;

namespace ReconDataLayer
{
	public class ReconversionData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter>? parameters;
		public DataSet ReconVersionfetchdata(ReconVersionmodellist Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_fetch_reconversion", CommandType.StoredProcedure, parameters.ToArray());
				if (ds.Tables.Count >= 4)
				{
					ds.Tables[0].TableName = "versionlist";
					ds.Tables[1].TableName = "Reconversion";
					ds.Tables[2].TableName = "theme";
					ds.Tables[3].TableName = "preprocess";
				}
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_fetch_reconversion" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_fetch_reconversion", headerval.user_code, constring);
				return ds;
			}
		}

		public DataSet ReconVersionhistorydata(ReconVersionhsitorylist Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_version_code", Objmodel.in_version_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_fetch_reconversionhistory", CommandType.StoredProcedure, parameters.ToArray());
				if (ds.Tables.Count >= 3)
				{
					ds.Tables[0].TableName = "versionlist";					
					ds.Tables[1].TableName = "theme";
					ds.Tables[2].TableName = "preprocess";
				}
				return ds;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_fetch_reconversionhistory" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_fetch_reconversionhistory", headerval.user_code, constring);
				return ds;
			}
		}

		public DataTable ReconVersionsavedata(ReconVersionmodelsave Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rule_code", Objmodel.in_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_theme_code", Objmodel.in_theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", Objmodel.in_preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_reconrule_version", Objmodel.in_reconrule_version, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_set_reconrule_version", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_set_reconrule_version" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_set_reconrule_version", headerval.user_code, constring);
				return result;
			}
		}
	}
}

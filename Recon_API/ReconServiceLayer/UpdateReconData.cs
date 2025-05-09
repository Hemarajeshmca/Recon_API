﻿using Newtonsoft.Json;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ReconModel;
using static ReconModels.UpdateReconModel;

namespace ReconDataLayer
{

	public class UpdateReconData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		List<IDbDataParameter>? parameters;

		public DataTable ReconUpdateRuleData(ReconUpdateRuleModel objReconUpdateRule, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_base_recon_code", objReconUpdateRule.in_base_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_base_rule_code", objReconUpdateRule.in_base_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_update_recon_code", objReconUpdateRule.in_update_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_update_rule_code", objReconUpdateRule.in_update_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objReconUpdateRule.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_upd_rule", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_upd_rule" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objReconUpdateRule), "pr_recon_upd_rule", headerval.user_code, constring);
				return result;
			}
		}

		public DataTable ReconUpdatePreprocessData(ReconUpdatePreprocessModel objReconUpdatePreprocess, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_base_recon_code", objReconUpdatePreprocess.in_base_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_base_preprocess_code", objReconUpdatePreprocess.in_base_preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_update_recon_code", objReconUpdatePreprocess.in_update_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_update_preprocess_code", objReconUpdatePreprocess.in_update_preprocess_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objReconUpdatePreprocess.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_upd_preprocess", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_upd_preprocess" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objReconUpdatePreprocess), "pr_recon_upd_preprocess", headerval.user_code, constring);
				return result;
			}
		}

		public DataTable ReconUpdateThemeData(ReconUpdateThemeModel objReconUpdateTheme, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_base_recon_code", objReconUpdateTheme.in_base_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_base_theme_code", objReconUpdateTheme.in_base_theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_update_recon_code", objReconUpdateTheme.in_update_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_update_theme_code", objReconUpdateTheme.in_update_theme_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objReconUpdateTheme.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_upd_theme", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_upd_theme" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objReconUpdateTheme), "pr_recon_upd_theme", headerval.user_code, constring);
				return result;
			}
		}
		//ReconagainstRuleData
		public DataTable ReconagainstRuleData(ReconagainstRuleModel objReconagainstRule, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_rule_name", objReconagainstRule.in_rule_name, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_reconagainstrule", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_reconagainstrule" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objReconagainstRule), "pr_get_reconagainstrule", headerval.user_code, constring);
				return result;
			}
		}

		//ReconagainstPreProcessData

		public DataTable ReconagainstPreProcessData(ReconagainstPreProcessModel objReconagainstPreProcess, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocess_name", objReconagainstPreProcess.in_preprocess_name, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_reconagainstpreprocess", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_reconagainstpreprocess" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objReconagainstPreProcess), "pr_get_reconagainstpreprocess", headerval.user_code, constring);
				return result;
			}
		}


		//ReconagainstThemeData
		public DataTable ReconagainstThemeData(ReconagainstThemeModel objReconagainstTheme, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_theme_name", objReconagainstTheme.in_theme_name, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_reconagainsttheme", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_reconagainsttheme" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objReconagainstTheme), "pr_get_reconagainsttheme", headerval.user_code, constring);
				return result;
			}
		}

        //datasetmapData

        public DataTable datasetmapData(datasetmapModel objdatasetmap, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_datasetmap_gid", objdatasetmap.in_datasetmap_gid, DbType.Int16, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objdatasetmap.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objdatasetmap.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objdatasetmap.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", objdatasetmap.in_action_by, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objdatasetmap.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_tdatasetmap", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_tdatasetmap" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objdatasetmap), "pr_recon_mst_tdatasetmap", headerval.user_code, constring);
                return result;
            }
        }


		//datasetlistmappedData
		public DataTable datasetlistmappedData(datasetlistmappedModel objdatasetlistmapped, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objdatasetlistmapped.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_target_recon_code", objdatasetlistmapped.in_target_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_datasetmapped_recon", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_datasetmapped_recon" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objdatasetlistmapped), "pr_get_datasetmapped_recon", headerval.user_code, constring);
				return result;
			}
		}
        public DataTable reconalllistData(Reconalllistmodel objReconalllistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", objReconalllistmodel.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_fecth_allreconlist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_trecon_list" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + JsonConvert.SerializeObject(objReconalllistmodel), "pr_recon_mst_trecon_list", headerval.user_code, constring);
                return result;
            }
        }
    }
}

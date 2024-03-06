using MySqlX.XDevAPI.Common;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.PreprocessModel;
using static ReconModels.ReconModel;
using static ReconModels.theme_model;

namespace ReconDataLayer
{
    public class PreprocessData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter>? parameters;

        public DataTable getPreprocessListData(Preprocesslistmodel objpreprocess, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objpreprocess.recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_preprocesslist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_preprocesslist" + "Error Message:" + ex.Message);
                return result;
            }
        }
		public DataTable preprocessHeaderdata(preprocessHeadermodel Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_preprocess_gid", Objmodel.preprocess_gid, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_code", Objmodel.preprocess_Code, DbType.String, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_preprocess_desc", Objmodel.preprocess_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_get_recon_field", Objmodel.get_recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_set_recon_field", Objmodel.set_recon_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_process_method", Objmodel.process_method, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_process_query", Objmodel.process_query, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_process_function", Objmodel.process_function, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lookup_dataset_code", Objmodel.lookup_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lookup_return_field", Objmodel.lookup_return_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_preprocess_order", Objmodel.preprocess_order, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", Objmodel.in_action_by, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tpreprocess", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tpreprocess" + "Error Message:" + ex.Message);
				return result;
			}
		}
	}
}

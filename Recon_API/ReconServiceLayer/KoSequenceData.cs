using System.Data;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using ReconModels;
using static ReconModels.KoSequenceModel;
using static ReconModels.UserManagementModel;

namespace ReconDataLayer
{
    public class KoSequenceData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter>? parameters;
        
        public DataTable KoSequenceSaveData(koseqsavemodel objkoseqsavemodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_koseq_gid", objkoseqsavemodel.in_Koseq_gid, DbType.Int16));             
                parameters.Add(dbManager.CreateParameter("in_recon_code", objkoseqsavemodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_version", objkoseqsavemodel.in_recon_version, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_Koseq_recon", objkoseqsavemodel.in_Koseq_recon, DbType.String));                            
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objkoseqsavemodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", objkoseqsavemodel.in_action_by, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_trn_tkoseq", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_trn_tkoseq" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objkoseqsavemodel), "pr_recon_trn_tkoseq", headerval.user_code, constring);
                return result;
            }
        }
        public DataTable seqlistfetchData(koseqlistmodel objkoseqlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objkoseqlistmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objkoseqlistmodel.in_user_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_koseqlist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_koseqtype" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_koseqtype", headerval.user_code, constring);
                return result;
            }
        }
        public DataSet Reconkoseqfetchdata(Reconkoseqmodellist Objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_fetch_koseqreconversion", CommandType.StoredProcedure, parameters.ToArray());
                if (ds.Tables.Count >= 4)
                {  
                    ds.Tables[0].TableName = "versionlist";
                    ds.Tables[1].TableName = "theme";
                    ds.Tables[2].TableName = "process";
                    ds.Tables[3].TableName = "preprocess";
                    ds.Tables[4].TableName = "postprocess";
                }
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_fetch_koseqreconversion" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_fetch_reconversion", headerval.user_code, constring);
                return ds;
            }
        }
        public DataTable seqlistdata(seqlistmodel seqlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();              
                parameters.Add(dbManager.CreateParameter("in_user_code", seqlistmodel.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_koseq", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_koseq" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_koseq", headerval.user_code, constring);
                return result;
            }
        }
        public DataTable Reconkoseqtree_db(Reconversiontreemodel Reconversiontreemodel,headerValue Objmodel, string constring)
        {
            List<treeviewllist> objList = new List<treeviewllist>();
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("ConnectionStrings");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", Reconversiontreemodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", Objmodel.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_process_code", Reconversiontreemodel.in_process_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_koseqlisttree", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];               
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:GetTreeNodes" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "GetTreeNodes", Objmodel.user_code, constring);
                return result;
            }
        }      
    }
}

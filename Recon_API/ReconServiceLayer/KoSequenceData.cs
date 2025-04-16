using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReconModels;
using static ReconModels.KoSequenceModel;
using static ReconModels.ReconModel;

namespace ReconDataLayer
{
    public class KoSequenceData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter>? parameters;
        public DataTable getseqtypeData(koseqmodel objkoseqmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objkoseqmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_seq_code", objkoseqmodel.in_seq_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objkoseqmodel.in_user_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_koseqtypefetch", CommandType.StoredProcedure, parameters.ToArray());
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
        public DataTable KoSequenceSaveData(koseqsavemodel objkoseqsavemodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_koseq_gid", objkoseqsavemodel.in_Koseq_gid, DbType.Int16, ParameterDirection.InputOutput));             
                parameters.Add(dbManager.CreateParameter("in_recon_code", objkoseqsavemodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_version", objkoseqsavemodel.in_recon_version, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_koseq_no", objkoseqsavemodel.in_koseq_no, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_koseq_type", objkoseqsavemodel.in_koseq_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_koseq_ref_code", objkoseqsavemodel.in_koseq_ref_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_hold_flag", objkoseqsavemodel.in_hold_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objkoseqsavemodel.in_active_status, DbType.String));              
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
    }
}

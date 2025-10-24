using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReconDataLayer.Interface;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ResultSetModel;

namespace ReconDataLayer
{
    public class KillJobData : IKillJobData
    {

        private string constring;
        List<IDbDataParameter>? parameters;
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        public KillJobData(IConfiguration configuration)
        {
            constring = configuration["Appsettings:ConnectionStrings"];
        }

        public DataTable getKillJobData(Int64 processId, string action, UserManagementModel.headerValue headerVal)
        {
            try
            {
                // serialize to JSON string
                //string jsonString = JsonConvert.SerializeObject(report);
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                //parameters.Add(dbManager.CreateParameter("in_archival_code", report.in_archival_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_process_id", processId, DbType.Int64));
                parameters.Add(dbManager.CreateParameter("in_action", action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerVal.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_set_killjob", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];

            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_set_killjob" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerVal), "pr_recon_set_killjob", headerVal.user_code, constring);
                throw ex;
            }
            return result;
        }

        public DataTable setKillJobData(Int64 processId, string action, UserManagementModel.headerValue headerVal)
        {
            try
            {
                // serialize to JSON string
                //string jsonString = JsonConvert.SerializeObject(report);
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                //parameters.Add(dbManager.CreateParameter("in_archival_code", report.in_archival_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_process_id", processId, DbType.Int64));
                parameters.Add(dbManager.CreateParameter("in_action", action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerVal.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_set_killjob", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];

            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_set_killjob" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerVal), "pr_recon_set_killjob", headerVal.user_code, constring);
                throw ex;
            }
            return result;
        }
    }
}

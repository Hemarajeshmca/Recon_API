using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ProcessModel;
using static ReconModels.ReportModel;

namespace ReconDataLayer
{
    public class ReportData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        DBManager dbManager = new DBManager("ConnectionString");
        List<IDbDataParameter>? parameters;

        public DataTable generatereportData(generatereportmodel objgeneratereportmodel, UserManagementModel.headerValue headerval)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_code", objgeneratereportmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_code", objgeneratereportmodel.in_report_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_param", objgeneratereportmodel.in_report_param, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_condition", objgeneratereportmodel.in_report_condition, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objgeneratereportmodel.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objgeneratereportmodel.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_outputfile_flag", objgeneratereportmodel.in_outputfile_flag, DbType.Boolean));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_run_report", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //reconbetweenaccData

        public DataTable reconbetweenaccData(reconbetweenaccmodel objreconbetweenaccmodel, UserManagementModel.headerValue headerval)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_code", objreconbetweenaccmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_tran_date", objreconbetweenaccmodel.in_tran_date, DbType.Date));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_get_brs", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //reconwithinaccData

        public DataTable reconwithinaccData(reconwithinaccmodel objreconwithinaccmodel, UserManagementModel.headerValue headerval)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_code", objreconwithinaccmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_tran_date", objreconwithinaccmodel.in_tran_date, DbType.Date));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_get_proof", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

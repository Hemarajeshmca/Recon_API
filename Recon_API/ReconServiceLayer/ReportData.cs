using Google.Protobuf;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ProcessModel;
using static ReconModels.ReconModel;
using static ReconModels.ReportModel;

namespace ReconDataLayer
{
    public class ReportData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter>? parameters;

        public DataTable generatereportData(generatereportmodel objgeneratereportmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objgeneratereportmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_code", objgeneratereportmodel.in_report_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_param", objgeneratereportmodel.in_report_param, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_condition", objgeneratereportmodel.reportcondition, DbType.String));
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
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_run_report" + "Error Message:" + ex.Message);
                throw ex;
            }

        }

        public DataTable reconbetweenaccData(reconbetweenaccmodel objreconbetweenaccmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
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
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_brs" + "Error Message:" + ex.Message);
                throw ex;
            }

        }

        //reconwithinaccData

        public DataTable reconwithinaccData(reconwithinaccmodel objreconwithinaccmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_code", objreconwithinaccmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_tran_date", objreconwithinaccmodel.in_tran_date, DbType.String));
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
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_proof" + "Error Message:" + ex.Message);
                throw ex;
            }

        }

		//getreportlistData
		public DataTable getreportlistData(UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();

				//parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_reportlist", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_reportlist" + "Error Message:" + ex.Message);
                throw ex;
			}

		}

		//getreportparamlistData
		public DataTable getreportparamlistData(reportparamlistmodel objreportparamlistmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();

				parameters.Add(dbManager.CreateParameter("in_report_code", objreportparamlistmodel.in_report_code, DbType.String));

				//parameters.Add(dbManager.CreateParameter("in_reportparam_gid", objreportparamlistmodel.in_reportparam_gid, DbType.Int32));
				//parameters.Add(dbManager.CreateParameter("in_action", objreportparamlistmodel.in_action, DbType.String));

				//parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_recon_mst_treportparam", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_treportparam" + "Error Message:" + ex.Message);
                throw ex;
			}

		}

        // Report

        public string[] ExectionReport(Report_model objmodel, string constring)
        {
            // DataTable result = new DataTable();
            string[] result = { };
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_report_code", objmodel.report_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_recon_gid", objmodel.recon_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_condition", objmodel.Report_condition, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objmodel.ip_address, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_outputfile_flag", objmodel.report_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objmodel.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_run_report", CommandType.StoredProcedure, parameters.ToArray());
                return result;
                //Dictionary<string, Object> values = new Dictionary<string, object>();
                //MSQLCON con = new MSQLCON(objmodel.ip_address, objmodel.user_code);
                //values.Add("in_report_code", objmodel.report_gid);
                //values.Add("in_recon_gid", objmodel.recon_gid);
                //values.Add("in_condition", objmodel.Report_condition);
                //values.Add("in_ip_addr", objmodel.ip_address);
                //values.Add("in_outputfile_flag", objmodel.in_outfile_flag);
                //values.Add("in_user_code", objmodel.user_code);
                //values.Add("out_msg", "out");
                //values.Add("out_result", "out");
                //result = con.RunDmlProc_FileConvert("pr_run_report", values);
                //return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_run_report" + "Error Message:" + ex.Message);
                throw ex;
            }
        }

    }
}

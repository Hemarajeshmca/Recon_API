using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ReconDataLayer
{
    public class KnockOffData
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public List<IDbDataParameter> parameters;
       // private readonly YourDbContext _context;

        public DataSet ReconMstTAcc(ReconMstTacc reconMstTacc, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();                
                parameters.Add(dbManager.CreateParameter("in_acc_gid", reconMstTacc.in_acc_gid, DbType.Int16,ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_acc_code", reconMstTacc.in_acc_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_acc_name", reconMstTacc.in_acc_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_acc_category", reconMstTacc.in_acc_category, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_acc_responsibility", reconMstTacc.in_acc_responsibility, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", reconMstTacc.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", reconMstTacc.in_action_by, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", reconMstTacc.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result","out" , DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_tacc", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_tacc" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(reconMstTacc), "pr_recon_mst_tacc", reconMstTacc.in_action_by, constring);
				throw ex;
            }

        }

        public DataSet runReport(RunReport runReport, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();               
                parameters.Add(dbManager.CreateParameter("in_report_code", runReport.in_report_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_gid", runReport.in_recon_gid, DbType.Int16));
                parameters.Add(dbManager.CreateParameter("in_condition", runReport.in_condition, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", runReport.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_outputfile_flag", runReport.in_outputfile_flag, DbType.Boolean));
                parameters.Add(dbManager.CreateParameter("in_user_code", runReport.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String,ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String,ParameterDirection.Output));               
                ds = dbManager.execStoredProcedure("pr_run_report", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_report" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(runReport), "pr_run_report", runReport.in_user_code, constring);
				throw ex;
            }

        }


		//runkosummData
		public DataSet runkosummData(runkosumm objrunkosumm, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objrunkosumm.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_period_from", objrunkosumm.in_period_from, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_period_to", objrunkosumm.in_period_to, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", objrunkosumm.in_ip_addr, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objrunkosumm.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedurelist("pr_get_kosumm", CommandType.StoredProcedure, parameters.ToArray());
				return ds;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_kosumm" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrunkosumm), "pr_get_kosumm", objrunkosumm.in_user_code, constring);
				throw ex;
			}
		}
		//recondatasetinfoData

		public DataSet recondatasetinfoData(recondatasetinfo objrecondatasetinfo, string constring)
		{
            DataSet ds = new DataSet();
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objrecondatasetinfo.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_dataset_code", objrecondatasetinfo.in_dataset_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_automatch_flag", objrecondatasetinfo.in_automatch_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedurelist("pr_get_recondatasetinfo", CommandType.StoredProcedure, parameters.ToArray());
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_recondatasetinfo" +" " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrecondatasetinfo), "pr_get_recondatasetinfo", "", constring);
				throw ex;
			}
		}

		public DataTable undorunreportData(runreportmodel objrunreport, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objrunreport.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objrunreport.in_report_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_param", objrunreport.in_report_param, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_condition", objrunreport.in_report_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", objrunreport.in_ip_addr, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_outputfile_flag", objrunreport.in_outputfile_flag, DbType.Boolean));
				parameters.Add(dbManager.CreateParameter("in_user_code", objrunreport.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_run_report", CommandType.StoredProcedure, parameters.ToArray());
				dt = ds.Tables[0];
				return dt;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_report" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrunreport), "pr_run_report", objrunreport.in_user_code, constring);
				throw ex;
			}
		}

		//undoKOData

		public DataTable undoKOData(undoKOmodel objundoKO, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_ko_gid", objundoKO.in_ko_gid, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_undo_ko_reason", objundoKO.in_undo_ko_reason, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objundoKO.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_set_undoko", CommandType.StoredProcedure, parameters.ToArray());
				dt = ds.Tables[0];
				return dt;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_set_undoko" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objundoKO), "pr_set_undoko", objundoKO.in_user_code, constring);
				throw ex;
			}
		}
		public DataTable undoKOjobData(undoKOjobModel objundoKO, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objundoKO.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_job_status", objundoKO.in_job_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_job_type", objundoKO.in_job_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_From_date", objundoKO.in_from_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_To_date", objundoKO.in_to_date, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_undojobprocess", CommandType.StoredProcedure, parameters.ToArray());
				dt = ds.Tables[0];
				return dt;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_set_undoko" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objundoKO), "pr_get_undojobprocess", "", constring);
				throw ex;
			}
		}
		public DataTable undomatchjobData(undomatchmodel objundoKO, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_job_gid", objundoKO.job_id, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objundoKO.reconcode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_undo_job_reason", objundoKO.undo_job_reason, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", objundoKO.in_ip_addr, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objundoKO.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_set_undokojob", CommandType.StoredProcedure, parameters.ToArray());
				dt = ds.Tables[0];
				return dt;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_set_undoko" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objundoKO), "pr_set_undokojob", objundoKO.in_user_code, constring);
				throw ex;
			}
		}

		//getundojobruleData
		public DataSet getundojobruleData(getundojobrulemodel objgetundojobrule, UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objgetundojobrule.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_start_date", objgetundojobrule.in_start_date, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_end_date", objgetundojobrule.in_end_date, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedurelist("pr_get_undokojobrule", CommandType.StoredProcedure, parameters.ToArray());
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_undokojobrule" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgetundojobrule), "pr_get_undokojobrule", headerval.user_code, constring);
				throw ex;
			}
		}


        //setundojobruleData
        public DataTable setundojobruleData(setundojobrulemodel objsetundojobrule, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objsetundojobrule.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_job_gid", objsetundojobrule.in_job_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_rule_code", objsetundojobrule.in_rule_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_undo_job_reason", objsetundojobrule.in_undo_job_reason, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_set_undokojobrule", CommandType.StoredProcedure, parameters.ToArray());
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_set_undokojobrule" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objsetundojobrule), "pr_set_undokojobrule", headerval.user_code, constring);
				throw ex;
            }
        }

		//getruleagainstjobData

		public DataTable getruleagainstjobData(getruleagainstjobmodel objgetruleagainstjob, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_job_gid", objgetruleagainstjob.in_job_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_ruleagainstjob", CommandType.StoredProcedure, parameters.ToArray());
				dt = ds.Tables[0];
				return dt;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_ruleagainstjob" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgetruleagainstjob), "pr_get_ruleagainstjob", headerval.user_code, constring);
				throw ex;
			}
		}

		//getthemeagainstReconData
		public DataTable getthemeagainstReconData(getthemeagainstReconmodel objgetthemeagainstRecon, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objgetthemeagainstRecon.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_themeagainstrecon", CommandType.StoredProcedure, parameters.ToArray());
				dt = ds.Tables[0];
				return dt;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_themeagainstrecon" + " " + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgetthemeagainstRecon), "pr_get_themeagainstrecon", headerval.user_code, constring);
				throw ex;
			}
		}
	}
}


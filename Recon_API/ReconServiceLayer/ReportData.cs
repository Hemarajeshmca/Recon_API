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

		//getreportparamlistserviceData
		public DataTable getreportparamlistreconData(reportparamlistmodel objreportparamlistmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();

				parameters.Add(dbManager.CreateParameter("in_report_code", objreportparamlistmodel.in_report_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objreportparamlistmodel.in_recon_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_reportparam", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_reportparam" + "Error Message:" + ex.Message);
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

        //MonthendReportData
        public async Task<DataSet> MonthendReportData(MonthendReportModel objMonthendReport, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                
                parameters.Add(dbManager.CreateParameter("in_recon_code", objMonthendReport.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_tran_date", objMonthendReport.in_tran_date, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedurelist("pr_get_brsmonthend", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_brsmonthend" + "Error Message:" + ex.Message);
                throw ex;
            }

        }

		//getReportTemplateListData

		public DataTable getReportTemplateListData(string constring, UserManagementModel.headerValue headerval)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_get_reporttemplate_list", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
                return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_reporttemplate_list" + "Error Message:" + ex.Message);
				throw ex;
			}

		}

		//reportTemplateData

		public DataTable reportTemplateData(reportTemplateModel objreportTemplate, string constring, UserManagementModel.headerValue headerval)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();

				parameters.Add(dbManager.CreateParameter("in_reporttemplate_gid", objreportTemplate.in_reporttemplate_gid, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objreportTemplate.in_reporttemplate_code, DbType.String, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_name", objreportTemplate.in_reporttemplate_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objreportTemplate.in_report_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objreportTemplate.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_active_status", objreportTemplate.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_system_flag", objreportTemplate.in_system_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String)); 
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_treporttemplate", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_treporttemplate" + "Error Message:" + ex.Message);
				throw ex;
			}

		}

		//fetchReportTemplateData
		public DataSet fetchReportTemplateData(fetchReportTemplateModel objfetchReportTemplate, string constring, UserManagementModel.headerValue headerval)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objfetchReportTemplate.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedurelist("pr_fetch_reporttemplate", CommandType.StoredProcedure, parameters.ToArray());
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_fetch_reporttemplate" + "Error Message:" + ex.Message);
				throw ex;
			}

		}
		//reporttemplatefilterData
		public DataTable reporttemplatefilterData(reporttemplatefilterModel objreporttemplatefilter, string constring, UserManagementModel.headerValue headerval)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_reporttemplatefilter_gid", objreporttemplatefilter.in_reporttemplatefilter_gid, DbType.Int32, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objreporttemplatefilter.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_seqno", objreporttemplatefilter.in_filter_seqno, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_report_field", objreporttemplatefilter.in_report_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_criteria", objreporttemplatefilter.in_filter_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_value", objreporttemplatefilter.in_filter_value, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_parentheses_flag", objreporttemplatefilter.in_open_parentheses_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_parentheses_flag", objreporttemplatefilter.in_close_parentheses_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", objreporttemplatefilter.in_join_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objreporttemplatefilter.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_treporttemplatefilter", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_treporttemplatefilter" + "Error Message:" + ex.Message);
				throw ex;
			}

		}

        //runPageReportData

        public DataTable runPageReportData(runPageReportModel objrunPageReport, string constring, UserManagementModel.headerValue headerval)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objrunPageReport.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_code", objrunPageReport.in_report_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_condition", objrunPageReport.in_report_condition, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_rec_count", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_run_pagereport", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_run_pagereport" + "Error Message:" + ex.Message);
                throw ex;
            }

        }

        //getPaginationreportData

        public DataTable getPaginationreportData(string constring, UserManagementModel.headerValue headerval)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_paginationreport", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_paginationreport" + "Error Message:" + ex.Message);
                throw ex;
            }

        }

        //getPageNoReportData

        public DataTable getPageNoReportData(getPageNoReportModel objgetPageNoReport, string constring, UserManagementModel.headerValue headerval)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objgetPageNoReport.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rptsession_gid", objgetPageNoReport.in_rptsession_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_page_no", objgetPageNoReport.in_page_no, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_page_size", objgetPageNoReport.in_page_size, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_tot_records", objgetPageNoReport.in_tot_records, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_get_pagenoreport", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_pagenoreport" + "Error Message:" + ex.Message);
                throw ex;
            }

        }

        //cloneReportTemplateData

        public DataTable cloneReportTemplateData(cloneReportTemplateModel objcloneReportTemplate, string constring, UserManagementModel.headerValue headerval)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_clone_reporttemplate_code", objcloneReportTemplate.in_clone_reporttemplate_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_reporttemplate_name", objcloneReportTemplate.in_reporttemplate_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_code", objcloneReportTemplate.in_report_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objcloneReportTemplate.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objcloneReportTemplate.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output)); 
				parameters.Add(dbManager.CreateParameter("out_reporttemplate_code", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_treporttemplate_clone", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_pagenoreport" + "Error Message:" + ex.Message);
                throw ex;
            }
        }
    }
}

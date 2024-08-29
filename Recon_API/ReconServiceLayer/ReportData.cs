using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Google.Protobuf.WellKnownTypes;
using Irony.Parsing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReconModels;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using static ReconModels.CommonModel;
using static ReconModels.ReconModel;
using static ReconModels.ReportModel;
using static ReconModels.UserManagementModel;

namespace ReconDataLayer
{
	public class ReportData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		List<IDbDataParameter>? parameters;

		private IConfiguration _configuration;

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
				parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objgeneratereportmodel.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_outputfile_flag", objgeneratereportmodel.in_outputfile_flag, DbType.Boolean));
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgeneratereportmodel), "pr_run_report", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreconbetweenaccmodel), "pr_get_brs", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreconwithinaccmodel), "pr_get_proof", headerval.user_code, constring);
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
				ds = dbManager.execStoredProcedure("pr_get_reportlist", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_reportlist" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_reportlist", headerval.user_code, constring);
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
				ds = dbManager.execStoredProcedure("pr_recon_mst_treportparam", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_treportparam" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreportparamlistmodel), "pr_recon_mst_treportparam", headerval.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreportparamlistmodel), "pr_get_reportparam", headerval.user_code, constring);
				throw ex;
			}

		}
		// Report

		public string[] ExectionReport(Report_model objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			string[] result = { };
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_report_code", objmodel.report_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_recon_gid", objmodel.recon_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_condition", objmodel.Report_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_outputfile_flag", objmodel.report_gid, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objmodel.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_run_report", CommandType.StoredProcedure, parameters.ToArray());
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_report" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objmodel), "pr_run_report", objmodel.user_code, constring);
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objMonthendReport), "pr_get_brsmonthend", headerval.user_code, constring);
				throw ex;
			}

		}

		//getReportTemplateListData

		public DataTable getReportTemplateListData(getReportTemplateListModel objgetReportTemplateListModel, string constring, UserManagementModel.headerValue headerval)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objgetReportTemplateListModel.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_custom_flag", objgetReportTemplateListModel.in_custom_flag, DbType.Boolean));
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgetReportTemplateListModel), "pr_get_reporttemplate_list", headerval.user_code, constring);
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
				parameters.Add(dbManager.CreateParameter("in_recon_code", objreportTemplate.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_sortby_code", objreportTemplate.in_sortby_code, DbType.String));
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreportTemplate), "pr_recon_mst_treporttemplate", headerval.user_code, constring);
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
				parameters.Add(dbManager.CreateParameter("in_recon_code", objfetchReportTemplate.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objfetchReportTemplate.in_report_code, DbType.String));
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objfetchReportTemplate), "pr_fetch_reporttemplate", headerval.user_code, constring);
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
				parameters.Add(dbManager.CreateParameter("in_filter_seqno", objreporttemplatefilter.in_filter_seqno, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_report_field", objreporttemplatefilter.in_report_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_criteria", objreporttemplatefilter.in_filter_criteria, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_filter_value", objreporttemplatefilter.in_filter_value, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_open_parentheses_flag", objreporttemplatefilter.in_open_parentheses_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_close_parentheses_flag", objreporttemplatefilter.in_close_parentheses_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_join_condition", objreporttemplatefilter.in_join_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_last_system_flag", objreporttemplatefilter.in_last_system_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objreporttemplatefilter.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreporttemplatefilter), "pr_recon_mst_treporttemplatefilter", headerval.user_code, constring);
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
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objrunPageReport.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objrunPageReport.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objrunPageReport.in_report_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_condition", objrunPageReport.in_report_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
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
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrunPageReport), "pr_run_pagereport", headerval.user_code, constring);
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
				ds = dbManager.execStoredProcedure("pr_get_paginationreport", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_paginationreport" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_paginationreport", headerval.user_code, constring);
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
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objgetPageNoReport.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objgetPageNoReport.in_report_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objgetPageNoReport.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_rptsession_gid", objgetPageNoReport.in_rptsession_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_condition", objgetPageNoReport.in_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_page_no", objgetPageNoReport.in_page_no, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_page_size", objgetPageNoReport.in_page_size, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_tot_records", objgetPageNoReport.in_tot_records, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_run_pagenoreport", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_pagenoreport" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgetPageNoReport), "pr_run_pagenoreport", headerval.user_code, constring);
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
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_gid", objcloneReportTemplate.in_reporttemplate_gid, DbType.Int16, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_clone_reporttemplate_code", objcloneReportTemplate.in_clone_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_name", objcloneReportTemplate.in_reporttemplate_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objcloneReportTemplate.in_report_code, DbType.String, ParameterDirection.InputOutput));
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
				objlog.logger("SP:pr_recon_mst_treporttemplate_clone" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objcloneReportTemplate), "pr_recon_mst_treporttemplate_clone", headerval.user_code, constring);
				throw ex;
			}
		}

		//reporttemplatefieldData

		public DataTable reporttemplatefieldData(reporttemplatefieldModel objreporttemplatefield, string constring, UserManagementModel.headerValue headerval)
		{
			try
			{
				DataTable JsonData = new DataTable();
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_jsonArray", objreporttemplatefield.templateJSON, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objreporttemplatefield.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_treporttemplatefield_new", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_treporttemplatefield_new" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreporttemplatefield), "pr_recon_mst_treporttemplatefield_new", headerval.user_code, constring);
				throw ex;
			}
		}
		//reporttemplatesortingData

		public DataTable reporttemplatesortingData(reporttemplatesortingModel objreporttemplatesorting, string constring, UserManagementModel.headerValue headerval)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_reporttemplatesorting_gid", objreporttemplatesorting.in_reporttemplatesorting_gid, DbType.Int16, ParameterDirection.InputOutput));
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objreporttemplatesorting.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_field", objreporttemplatesorting.in_report_field, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_sorting_order", objreporttemplatesorting.in_sorting_order, DbType.Decimal));
				parameters.Add(dbManager.CreateParameter("in_active_status", objreporttemplatesorting.in_active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objreporttemplatesorting.in_action, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objreporttemplatesorting.in_action_by, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_delete_flag", objreporttemplatesorting.in_delete_flag, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_treporttemplatesorting", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_mst_treporttemplatesorting" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreporttemplatesorting), "pr_recon_mst_treporttemplatesorting", headerval.user_code, constring);
				throw ex;
			}
		}

		//uploadreporttempletefileData

		public DataTable uploadreporttempletefileData(uploadreporttempletefileModel objuploadreporttempletefile, string constring, UserManagementModel.headerValue headerval)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objuploadreporttempletefile.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_file_name", objuploadreporttempletefile.in_file_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_file_path", objuploadreporttempletefile.in_file_path, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action_by", objuploadreporttempletefile.in_action_by, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_upload_templetefile", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_upload_templetefile" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objuploadreporttempletefile), "pr_upload_templetefile", headerval.user_code, constring);
				throw ex;
			}
		}

		//generatedynamicReportData

		public DataTable generatedynamicReportData(generatedynamicReportmodel objgeneratedynamicReport, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DataSet dataset = new DataSet();
				DataTable dt = new DataTable();
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objgeneratedynamicReport.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objgeneratedynamicReport.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objgeneratedynamicReport.in_report_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_param", objgeneratedynamicReport.in_report_param, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_condition", objgeneratedynamicReport.in_report_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_outputfile_flag", objgeneratedynamicReport.in_outputfile_flag, DbType.Boolean));
				parameters.Add(dbManager.CreateParameter("in_outputfile_type", objgeneratedynamicReport.in_outputfile_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				dataset = dbManager.execStoredProcedurelist("pr_run_dynamicreport", CommandType.StoredProcedure, parameters.ToArray());
				if (objgeneratedynamicReport.in_outputfile_type == "csv")
				{
					string insertintojob = "";
					dt = dataset.Tables[0];
					var job_id = dataset.Tables[0].Rows[0]["result"];
					var filename = job_id + "_" + objgeneratedynamicReport.in_report_name;
					if (job_id != null)
					{
						insertintojob = insertfileName(filename, job_id, constring, headerval.user_code);

					}
					return dt;

				}
				else
				{
					string sourceFile = "";
					var job_id = dataset.Tables[1].Rows[0]["result"];
					var filename = job_id + "_" + objgeneratedynamicReport.in_report_name;
					string getsourcefolderpath = roleconfig_db("folder_path", constring);
					if (objgeneratedynamicReport.file_name == "" || objgeneratedynamicReport.in_reporttemplate_code == "")
					{
						sourceFile = roleconfig_db("temp_file_folder_path", constring);
					}
					else
					{
						sourceFile = getsourcefolderpath + objgeneratedynamicReport.in_reporttemplate_code + ".xlsx";
					}
					string getdestFile = roleconfig_db("xlsx_folder_path", constring);
					string destFile = getdestFile + filename + ".xlsx";
					string insertintojob = "";
					if (job_id != null)
					{
						insertintojob = insertfileName(filename, job_id, constring, headerval.user_code);
					}

					if (insertintojob == "Success")
					{
						string sheetName = "Data";
						File.Copy(sourceFile, destFile, true);
						using (var workbook = new XLWorkbook(destFile))
						{
							var worksheet = workbook.Worksheet(sheetName);
							worksheet.Clear(XLClearOptions.Contents);
							try
							{
								if (dataset.Tables[0].Rows.Count > 0)
								{
									worksheet.Cell(1, 1).InsertTable(dataset.Tables[0].AsEnumerable(), "MyTable", true);
								}
								else
								{
									worksheet.Cell(1, 1).InsertData("No Record Found");
								}
								workbook.SaveAs(destFile);
							}
							catch (Exception ex)
							{
								Console.WriteLine($"An error occurred while inserting table: {ex.Message}");
								throw;
							}
						}
					}
					dt = dataset.Tables[1];
					return dt;
				}

			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_dynamicreport" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgeneratedynamicReport), "pr_run_dynamicreport", headerval.user_code, constring);
				throw ex;
			}
		}

		public string roleconfig_db(string in_config_name, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_config_name", in_config_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_config_value", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_get_configvalue", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				string outMsgValue = parameters[1].Value.ToString();
				return outMsgValue;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(in_config_name), "pr_get_configvalue", "", constring);
				return "failed";
			}
		}



		public string insertfileName(string file_name, object job_id, string constring, string user_code)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				int getjobId = Convert.ToInt32(job_id.ToString());
				parameters.Add(dbManager.CreateParameter("in_file_name", file_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_job_id", getjobId, DbType.Int64));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_trn_tjob", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				string outMsgValue = parameters[2].Value.ToString();
				return outMsgValue;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(job_id), "pr_get_configvalue", "", constring);
				return "failed";
			}
		}


		public string UpdateJobStatus(object job_id, string job_status, string job_remark, string constring, string user_code)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				int getjobId = Convert.ToInt32(job_id.ToString());
				parameters.Add(dbManager.CreateParameter("in_job_gid", job_id, DbType.Int64));
				parameters.Add(dbManager.CreateParameter("in_job_status", job_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_job_remark", job_remark, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_upd_job", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				string outMsgValue = parameters[2].Value.ToString();
				return outMsgValue;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(job_id), "pr_get_configvalue", "", constring);
				return "failed";
			}
		}


		public DataTable generatedynamicReportData_new(ReportModel.DataModel objDataModel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DataTable getfiledType = new DataTable();
				DataTable getDateFormat = new DataTable();
				DataTable getDateTimeFormat = new DataTable();
				DataTable JsonData = new DataTable();
				DataTable sheetDt = new DataTable();
				DataSet dataset = new DataSet();
				DataTable dt = new DataTable();
				JsonData = JsonConvert.DeserializeObject<DataTable>(objDataModel.Dataset1);
				JArray jsonArray = JArray.Parse(objDataModel.Dataset2);
				sheetDt.Columns.Add("Filter Seq No", typeof(int));
				sheetDt.Columns.Add("(", typeof(string));
				sheetDt.Columns.Add("Filter Field", typeof(string));
				sheetDt.Columns.Add("Filter Criteria", typeof(string));
				sheetDt.Columns.Add("Filter Value", typeof(string));
				sheetDt.Columns.Add(")", typeof(string));
				sheetDt.Columns.Add("Joins", typeof(string));
				foreach (JObject obj in jsonArray)
				{
					DataRow newRow = sheetDt.NewRow();
					newRow["Filter Seq No"] = (int)obj["filter_seqno"];
					newRow["("] = (string)obj["open_parentheses_flag"];
					newRow["Filter Field"] = (string)obj["reportparam_value"];
					newRow["Filter Criteria"] = (string)obj["filter_criteria_desc"];
					newRow["Filter Value"] = (string)obj["filter_value"];
					newRow[")"] = (string)obj["close_parentheses_flag"];
					newRow["Joins"] = (string)obj["join_condition"];
					sheetDt.Rows.Add(newRow);
				}
				var objgeneratedynamicReport = JsonData.Rows[0];
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objgeneratedynamicReport["in_reporttemplate_code"], DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objgeneratedynamicReport["in_recon_code"], DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objgeneratedynamicReport["in_report_code"], DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_param", objgeneratedynamicReport["in_report_param"], DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_condition", objgeneratedynamicReport["in_report_condition"], DbType.String));
				parameters.Add(dbManager.CreateParameter("in_outputfile_flag", objgeneratedynamicReport["in_outputfile_flag"], DbType.Boolean));
				parameters.Add(dbManager.CreateParameter("in_outputfile_type", objgeneratedynamicReport["in_outputfile_type"], DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				dataset = dbManager.execStoredProcedurelist("pr_run_dynamicreport", CommandType.StoredProcedure, parameters.ToArray());
				if (objgeneratedynamicReport["in_outputfile_type"] == "csv")
				{
					string insertintojob = "";
					dt = dataset.Tables[0];
					var job_id = dataset.Tables[0].Rows[0]["result"];
					var filename = job_id + "_" + objgeneratedynamicReport["in_report_name"];
					if (job_id != null)
					{
						insertintojob = insertfileName(filename, job_id, constring, headerval.user_code);
					}
					return dt;
				}
				else
				{
					string sourceFile = "";
					var job_id = dataset.Tables[1].Rows[0]["result"];
					var filename = job_id + "_" + objgeneratedynamicReport["in_report_name"];
					string getsourcefolderpath = roleconfig_db("folder_path", constring);
					if (objgeneratedynamicReport["file_name"] == "" || objgeneratedynamicReport["in_reporttemplate_code"] == "")
					{
						sourceFile = roleconfig_db("temp_file_folder_path", constring);
					}
					else
					{
						sourceFile = getsourcefolderpath + objgeneratedynamicReport["in_reporttemplate_code"] + ".xlsx";
					}
					string getdestFile = roleconfig_db("xlsx_folder_path", constring);
					string destFile = getdestFile + filename + ".xlsx";
					string insertintojob = "";
					if (job_id != null)
					{
						insertintojob = insertfileName(filename, job_id, constring, headerval.user_code);
					}
					if (insertintojob == "Success")
					{
						Debugger.Break();
						getfiledType = getReportFieldType(objDataModel, headerval, constring);
						getDateFormat = configvalueData("excel_dateformat", headerval, constring);
						getDateTimeFormat = configvalueData("excel_datetimeformat", headerval, constring);
						string sheetName = "Data";
						File.Copy(sourceFile, destFile, true);
						using (var workbook = new XLWorkbook(destFile))
						{
							var worksheet = workbook.Worksheet(sheetName);
							worksheet.Clear(XLClearOptions.Contents);
							try
							{
								if (dataset.Tables[0].Rows.Count > 0)
								{
									worksheet.Clear();
									var table = worksheet.Cell(1, 1).InsertTable(dataset.Tables[0].AsEnumerable(), "MyTable", true);
									for (int j = 0; j < dataset.Tables[0].Columns.Count; j++)
									{
										for (int i = 0; i < getfiledType.Rows.Count; i++)
										{
											var column = table.Column(i + 1);
											var dataType = "";
											if (dataset.Tables[0].Columns[j].ColumnName.ToString() == getfiledType.Rows[i]["field_alias_name"].ToString())
											{
												dataType = getfiledType.Rows[i]["field_type"].ToString();
												if (dataType == "DATE")
												{
													foreach (var cell in column.CellsUsed())
													{
														if (DateTime.TryParse(cell.GetString(), out DateTime parsedDate))
														{
															cell.Value = parsedDate;
															cell.Style.DateFormat.Format = getDateFormat.Rows[0]["out_config_value"].ToString(); // Apply date format
														}
													}
												}
												else if (dataType == "DATETIME")
												{
													foreach (var cell in column.CellsUsed())
													{
														if (DateTime.TryParse(cell.GetString(), out DateTime parsedDate))
														{
															cell.Value = parsedDate;
															cell.Style.DateFormat.Format = getDateTimeFormat.Rows[0]["out_config_value"].ToString(); // Apply date format
														}
													}
												}
												else if (dataType == "DECIMAL" || dataType == "NUMERIC")
												{
													column.Style.NumberFormat.Format = "#,##0.00";
												}
												else if (dataType == "INTEGER")
												{
													column.Style.NumberFormat.Format = "0";
												}
												else
												{
													column.Style.NumberFormat.Format = "";
												}
											}
										}
									}
									//for (int colIndex = 0; colIndex < dataset.Tables[0].Columns.Count; colIndex++)
									//{
									//    var column = table.Column(colIndex + 1); // ClosedXML columns are 1-based
									//    var dataType = dataset.Tables[0].Columns[colIndex].DataType;
									//    if (dataType == typeof(DateOnly) || dataType == typeof(DateTime))
									//    {
									//        column.Style.NumberFormat.Format = "yyyy-mm-dd"; // Adjust date format as needed
									//    }
									//    else if (dataType == typeof(decimal) || dataType == typeof(double) || dataType == typeof(float))
									//    {
									//        column.Style.NumberFormat.Format = "#,##0.00"; // Adjust number format as needed
									//    }
									//    else if (dataType == typeof(int) || dataType == typeof(long))
									//    {
									//        column.Style.NumberFormat.Format = "0"; // No decimal points
									//    }
									//}
									//worksheet.Cells().Style.Protection.SetLocked(false);
									//// Lock the specific column (make it read-only)
									//worksheet.Column("B").Style.Protection.SetLocked(true);
									//worksheet.Protect();
								}
								else
								{
									worksheet.Cell(1, 1).InsertData("No Record Found");
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine($"An error occurred while inserting table: {ex.Message}");
								throw;
							}
							var worksheet2 = workbook.Worksheets.Add("Condition Criteria");
							worksheet2.Clear(XLClearOptions.Contents);
							try
							{
								if (sheetDt.Rows.Count > 0)
								{
									var table = worksheet2.Cell(1, 1).InsertTable(sheetDt.AsEnumerable(), "MyTable", true);

								}
								else
								{
									worksheet2.Cell(1, 1).InsertData("No Record Found");
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine($"An error occurred while inserting table into {"Sheet2"}: {ex.Message}");
								throw;
							}
							workbook.SaveAs(destFile);
							UpdateJobStatus(job_id, "C", "Completed", constring, headerval.user_code);
						}
					}
					dt = dataset.Tables[1];
					return dt;
				}
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_dynamicreport" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objDataModel), "pr_run_dynamicreport", headerval.user_code, constring);
				throw ex;
			}
		}

		//customReport_brsSummaryData

		public DataSet customReport_brsSummaryData(customReport_brsSummaryModel objbrsSummaryModel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objbrsSummaryModel.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_tran_date", objbrsSummaryModel.in_tran_date, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedurelist("pr_get_brssummary", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_brs" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objbrsSummaryModel), "pr_get_brs", headerval.user_code, constring);
				throw ex;
			}
		}



		//generatedynamicReport_typeCData
		public DataSet generatedynamicReport_typeCData(generatedynamicReport_typeCmodel objgeneratedynamicReport, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DataSet dataset = new DataSet();
				DataTable dt = new DataTable();
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objgeneratedynamicReport.in_reporttemplate_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objgeneratedynamicReport.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objgeneratedynamicReport.in_report_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_param", objgeneratedynamicReport.in_report_param, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_condition", objgeneratedynamicReport.in_report_condition, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_outputfile_flag", objgeneratedynamicReport.in_outputfile_flag, DbType.Boolean));
				parameters.Add(dbManager.CreateParameter("in_outputfile_type", objgeneratedynamicReport.in_outputfile_type, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				dataset = dbManager.execStoredProcedurelist("pr_run_dynamicreport", CommandType.StoredProcedure, parameters.ToArray());
				int getsheetcount = dataset.Tables[0].Rows.Count;
				var job_id = dataset.Tables[0].Rows[0]["result"];
				var filename = job_id + "_" + objgeneratedynamicReport.in_report_name;
				string getdestFile = roleconfig_db("xlsx_folder_path", constring);
				string sourceFile = roleconfig_db("temp_file_folder_path_dynamic", constring);
				string destFile = getdestFile + filename + ".xlsx";
				CreateExcelFile(dataset, sourceFile, destFile);
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_run_dynamicreport" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgeneratedynamicReport), "pr_run_dynamicreport", headerval.user_code, constring);
				throw ex;
			}
		}

		private void CreateExcelFile(DataSet dataSet, string sourceFile, string destFile)
		{
			File.Copy(sourceFile, destFile, true);
			using (var workbook = new XLWorkbook())
			{
				DataTable resultset1 = dataSet.Tables[1];
				for (int i = 0; i < resultset1.Rows.Count; i++)
				{
					string sheetName = resultset1.Rows[i]["sheet_name"].ToString();
					int dataSetIndex = i + 2;
					if (dataSet.Tables.Count > dataSetIndex)
					{
						DataTable dataTable = dataSet.Tables[dataSetIndex];
						var worksheet = workbook.Worksheets.Add(sheetName);
						worksheet.Clear(XLClearOptions.Contents);
						try
						{
							if (dataTable.Rows.Count > 0)
							{
								worksheet.Cell(1, 1).InsertTable(dataTable.AsEnumerable());
								//worksheet.Cells().Style.Protection.SetLocked(false);

								//// Lock the specific column (make it read-only)
								//worksheet.Column("B").Style.Protection.SetLocked(true);
								//worksheet.Protect();

							}
							else
							{
								worksheet.Cell(1, 1).Value = "No Record Found";
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine($"An error occurred while inserting table into {sheetName}: {ex.Message}");
							throw;
						}
					}
				}
				workbook.SaveAs(destFile);
			}
		}

		public DataTable getReportFieldType(ReportModel.DataModel objDataModel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DataTable dt = new DataTable();
				dt = JsonConvert.DeserializeObject<DataTable>(objDataModel.Dataset1);
				var objgeneratedynamicReport = dt.Rows[0];
				DBManager dbManager = new DBManager(constring);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_reporttemplate_code", objgeneratedynamicReport["in_reporttemplate_code"], DbType.String));
				parameters.Add(dbManager.CreateParameter("in_recon_code", objgeneratedynamicReport["in_recon_code"], DbType.String));
				parameters.Add(dbManager.CreateParameter("in_report_code", objgeneratedynamicReport["in_report_code"], DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_get_reportfieldtype", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_reportfieldtype" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objDataModel.Dataset1), "pr_get_reportfieldtype", headerval.user_code, constring);
				throw ex;
			}
		}


		public DataTable configvalueData(string objconfigvalue, headerValue hv, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_config_name", objconfigvalue, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_config_value", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_get_configvalue", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_configvalue" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objconfigvalue), "pr_get_configvalue", hv.user_code, constring);
				throw ex;
			}
		}


	}
}

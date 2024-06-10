using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ReconModel;
using static ReconModels.ReportModel;

namespace ReconServiceLayer
{
    public class ReportService
    {
        public static DataTable generatereportservice(generatereportmodel objgeneratereportmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                ds = objreport.generatereportData(objgeneratereportmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        //reconbetweenaccservice

        public static DataTable reconbetweenaccservice(reconbetweenaccmodel objreconbetweenaccmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                ds = objreport.reconbetweenaccData(objreconbetweenaccmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        //reconwithinaccservice
        public static DataTable reconwithinaccservice(reconwithinaccmodel objreconwithinaccmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                ds = objreport.reconwithinaccData(objreconwithinaccmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

		//getreportlistservice
		public static DataTable getreportlistservice(UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReportData objreport = new ReportData();
				ds = objreport.getreportlistData(headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//getreportparamlistservice
		public static DataTable getreportparamlistservice(reportparamlistmodel objreportparamlistmodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReportData objreport = new ReportData();
				ds = objreport.getreportparamlistData(objreportparamlistmodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//getreportparamlistreconservice
		public static DataTable getreportparamlistreconservice(reportparamlistmodel objreportparamlistmodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReportData objreport = new ReportData();
				ds = objreport.getreportparamlistreconData(objreportparamlistmodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		//Report

		public static string[] ExectionReport(Report_model objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            string[] result = { };
           // FileConvTemp_model user = new FileConvTemp_model();
            try
            {
                //Report_datamodel objproduct = new Report_datamodel();

                //result = objproduct.ExectionReport(objmodel);
                //if (result.Length == 2)
                //{
                //    user.result = Convert.ToInt32(result[1]);
                //    user.msg = result[0];
                //}
                //else
                //{
                //    user.result = 0;
                //    user.msg = "Process Failed";
                //}

                return result;
            }
            catch (Exception e)
            {
                string control = "ReportService";

            }
            return result;
        }


        //MonthendReportService

        public static async Task<DataSet> MonthendReportService(MonthendReportModel objMonthendReport, UserManagementModel.headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                ReportData objreport = new ReportData();
                ds = await objreport.MonthendReportData(objMonthendReport, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
		//getReportTemplateListService
		public static DataTable getReportTemplateListService(getReportTemplateListModel objgetReportTemplateListModel, string constring, UserManagementModel.headerValue headerval)
		{
			DataTable dt = new DataTable();
			try
			{
				ReportData objreport = new ReportData();
				dt = objreport.getReportTemplateListData(objgetReportTemplateListModel, constring, headerval);
			}
			catch (Exception e)
			{ }
			return dt;
		}

        //reportTemplateService
        public static DataTable reportTemplateService(reportTemplateModel objreportTemplate, string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.reportTemplateData(objreportTemplate, constring, headerval);
            }
            catch (Exception e)
            { }
            return dt;
        }

		//fetchReportTemplateService
		public static DataSet fetchReportTemplateService(fetchReportTemplateModel objfetchReportTemplate, string constring, UserManagementModel.headerValue headerval)
		{
			DataSet ds = new DataSet();
			try
			{
				ReportData objreport = new ReportData();
				ds = objreport.fetchReportTemplateData(objfetchReportTemplate, constring, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//reporttemplatefilterService

		public static DataTable reporttemplatefilterService(reporttemplatefilterModel objreporttemplatefilter, string constring, UserManagementModel.headerValue headerval)
		{
			DataTable dt = new DataTable();
			try
			{
				ReportData objreport = new ReportData();
				dt = objreport.reporttemplatefilterData(objreporttemplatefilter, constring, headerval);
			}
			catch (Exception e)
			{ }
			return dt;
		}


        //runPageReportService

        public static DataTable runPageReportService(runPageReportModel objrunPageReport, string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.runPageReportData(objrunPageReport, constring, headerval);
            }
            catch (Exception e)
            { }
            return dt;
        }

        //getPaginationreportService
        public static DataTable getPaginationreportService(string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.getPaginationreportData(constring, headerval);
            }
            catch (Exception e)
            { }
            return dt;
        }

        //getPageNoReportService

        public static DataTable getPageNoReportService(getPageNoReportModel objgetPageNoReport, string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.getPageNoReportData(objgetPageNoReport, constring, headerval);
            }
            catch (Exception e)
            { }
            return dt;
        }


        //cloneReportTemplateService
        public static DataTable cloneReportTemplateService(cloneReportTemplateModel objcloneReportTemplate, string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.cloneReportTemplateData(objcloneReportTemplate, constring, headerval);
            }
            catch (Exception e)
            { }
            return dt;
        }

        //reporttemplatefieldService
        public static DataTable reporttemplatefieldService(reporttemplatefieldModel objreporttemplatefield, string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.reporttemplatefieldData(objreporttemplatefield, constring, headerval);
            }
            catch (Exception e)
            { }
            return dt;
        }

        //reporttemplatesortingService

        public static DataTable reporttemplatesortingService(reporttemplatesortingModel objreporttemplatesorting, string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.reporttemplatesortingData(objreporttemplatesorting, constring, headerval);
            }
            catch (Exception e)
            { }
            return dt;
        }

        //uploadreporttempletefileService

        public static DataTable uploadreporttempletefileService(uploadreporttempletefileModel objuploadreporttempletefile, string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.uploadreporttempletefileData(objuploadreporttempletefile, constring, headerval);
            }
            catch (Exception e)
            { }
            return dt;
        }

        //generatedynamicReportservice

        public static DataTable generatedynamicReportservice(generatedynamicReportmodel objgeneratedynamicReport, string constring, UserManagementModel.headerValue headerval)
        {
            DataTable dt = new DataTable();
            try
            {
                ReportData objreport = new ReportData();
                dt = objreport.generatedynamicReportData(objgeneratedynamicReport, headerval, constring);
            }
            catch (Exception e)
            { }
            return dt;
        }

        public static DataTable generatedynamicReportservice_new(DataModel objDataModel, string constring, UserManagementModel.headerValue headerval)
		{
			DataTable dt = new DataTable();
			try
			{
				ReportData objreport = new ReportData();
				dt = objreport.generatedynamicReportData_new(objDataModel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return dt;
		}

        //customReport_brsSummaryservice

        public static DataSet customReport_brsSummaryservice(customReport_brsSummaryModel objbrsSummaryModel, UserManagementModel.headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                ReportData objreport = new ReportData();
                ds = objreport.customReport_brsSummaryData(objbrsSummaryModel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

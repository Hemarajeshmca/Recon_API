﻿using ReconDataLayer;
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

        //Report

        public static string[] ExectionReport(Report_model objmodel, string constring)
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
		public static DataTable getReportTemplateListService(string constring, UserManagementModel.headerValue headerval)
		{
			DataTable dt = new DataTable();
			try
			{
				ReportData objreport = new ReportData();
				dt = objreport.getReportTemplateListData(constring, headerval);
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
	}
}

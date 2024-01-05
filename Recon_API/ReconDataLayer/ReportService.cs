using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}

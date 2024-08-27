using Microsoft.Extensions.Configuration;
using ReconDataLayer;
using ReconModels;
using System.Data;
using static ReconModels.ReconVersionmodel;

namespace ReconServiceLayer
{
    public class ReconVersionSrv
	{
        public static DataSet ReconVersionfetch(ReconVersionmodellist ReconVersionmodellist, UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				ReconversionData objDS = new ReconversionData();
				ds = objDS.ReconVersionfetchdata(ReconVersionmodellist, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataSet ReconVersionhistory(ReconVersionhsitorylist ReconVersionhsitorylist, UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				ReconversionData objDS = new ReconversionData();
				ds = objDS.ReconVersionhistorydata(ReconVersionhsitorylist, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable ReconVersionsave(ReconVersionmodelsave ReconVersionmodelsave, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconversionData objDS = new ReconversionData();
				ds = objDS.ReconVersionsavedata(ReconVersionmodelsave, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

        //ReconReportVersionhistoryService

        public byte[] ReconReportVersionhistoryService(ReconReportVersionhistoryModel objReconReportVersionhistory, UserManagementModel.headerValue headerval, string constring, string logoPath)
        {
            DataSet ds = new DataSet();
            try
            {
                ReconversionData objDS = new ReconversionData();
                byte[] pdfBytes = objDS.ReconReportVersionhistoryData(objReconReportVersionhistory, headerval, constring, logoPath);
				// return File(pdfBytes, "application/pdf", "Recon_Version.pdf");
				return pdfBytes;
            }
            catch (Exception e)
            { }
            return null;
        }
    }
}

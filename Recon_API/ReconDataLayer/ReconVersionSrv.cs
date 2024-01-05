using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasettoReconmodel;
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

		public static DataTable ReconVersionhistory(ReconVersionhsitorylist ReconVersionhsitorylist, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
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
	}
}

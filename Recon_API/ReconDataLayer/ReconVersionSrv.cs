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
		public static DataTable ReconVersionfetch(ReconVersionmodellist ReconVersionmodellist, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconversionData objDS = new ReconversionData();
				ds = objDS.ReconVersionfetchdata(ReconVersionmodellist, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable ReconVersionsave(ReconVersionmodelsave ReconVersionmodelsave, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconversionData objDS = new ReconversionData();
				ds = objDS.ReconVersionsavedata(ReconVersionmodelsave, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

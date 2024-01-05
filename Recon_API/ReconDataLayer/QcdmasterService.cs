using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.QcdmasterModel;

namespace ReconServiceLayer
{
	public class QcdmasterService
	{
		public static DataTable QcdMasterRead(QcdmasterModel objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				QcdmastersData objqcd = new QcdmastersData();
				ds = objqcd.QcdModeldataRead(objmodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable QcdMasterGridRead(Qcdgridread objgridread, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				QcdmastersData objqcd = new QcdmastersData();
				ds = objqcd.QcdModeldataGridRead(objgridread, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable QcdMasters(mainQCDMaster objmaster, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				QcdmastersData objqcd = new QcdmastersData();
				ds = objqcd.QcdMaster(objmaster, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

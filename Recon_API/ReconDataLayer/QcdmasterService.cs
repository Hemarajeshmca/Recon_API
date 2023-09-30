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
		public static DataTable QcdMasterRead(QcdmasterModel objmodel)
		{
			DataTable ds = new DataTable();
			try
			{
				QcdmastersData objqcd = new QcdmastersData();
				ds = objqcd.QcdModeldataRead(objmodel);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable QcdMasterGridRead(Qcdgridread objgridread)
		{
			DataTable ds = new DataTable();
			try
			{
				QcdmastersData objqcd = new QcdmastersData();
				ds = objqcd.QcdModeldataGridRead(objgridread);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable QcdMasters(mainQCDMaster objmaster)
		{
			DataTable ds = new DataTable();
			try
			{
				QcdmastersData objqcd = new QcdmastersData();
				ds = objqcd.QcdMaster(objmaster);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

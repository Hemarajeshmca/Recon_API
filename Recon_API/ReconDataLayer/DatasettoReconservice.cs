using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
using static ReconModels.DatasettoReconmodel;

namespace ReconServiceLayer
{
	public class DatasettoReconservice
	{
		public static DataTable DatasettoReconRead(DatasettoReconmodellist DatasettoReconmodellist, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasettoRecondata objDS = new DatasettoRecondata();
				ds = objDS.DatasettoReconReaddata(DatasettoReconmodellist, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasettoReconprocess(DatasettoReconmodelprocess DatasettoReconmodelprocess, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasettoRecondata objDS = new DatasettoRecondata();
				ds = objDS.DatasettoReconprocessdata(DatasettoReconmodelprocess, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;

namespace ReconServiceLayer
{
	public class DatasetService
	{
		public static DataTable DatasetRead(Datasetlistmodel Datasetlistmode, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetReaddata(Datasetlistmode, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasetHeader(DatasetHeadermodel Datasetheadermodel, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetHeaderdata(Datasetheadermodel, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasetDetail(Datasetdetailmodel Datasetheadermodel, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetDetaildata(Datasetheadermodel, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataSet DatasetReaddetail(Datasetdetailmodellist Datasetdetailmodellist, UserManagementModel.headerValue headerval)
		{
			DataSet ds = new DataSet();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetReaddetaildata(Datasetdetailmodellist, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getfieldtype(UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.getfieldtype(headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}


        public static DataTable CloneDataset(clonedataset objclonedataset)
        {
            DataTable ds = new DataTable();
            try
            {
                DatasetData objDS = new DatasetData();
                ds = objDS.cloneDatasetdata(objclonedataset);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

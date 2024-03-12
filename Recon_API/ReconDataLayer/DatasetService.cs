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
		public static DataTable DatasetRead(Datasetlistmodel Datasetlistmode, UserManagementModel.headerValue headerval,string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetReaddata(Datasetlistmode, headerval,constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasetHeader(DatasetHeadermodel Datasetheadermodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetHeaderdata(Datasetheadermodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasetDetail(Datasetdetailmodel Datasetheadermodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetDetaildata(Datasetheadermodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataSet DatasetReaddetail(Datasetdetailmodellist Datasetdetailmodellist, UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetReaddetaildata(Datasetdetailmodellist, headerval,constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getfieldtype(UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.getfieldtype(headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}


        public static DataTable CloneDataset(clonedataset objclonedataset, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                DatasetData objDS = new DatasetData();
                ds = objDS.cloneDatasetdata(objclonedataset, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

		//getSchedulerService
		public static DataTable getSchedulerService(getSchedulerModel objgetScheduler, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.getSchedulerData(objgetScheduler, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//delSchedulerService
		public static DataTable delSchedulerService(delSchedulerModel objdelScheduler, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.delSchedulerData(objdelScheduler, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

        //datasetAgainstReconService

        public static DataTable datasetAgainstReconService(datasetAgainstReconModel objdatasetAgainstRecon, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                DatasetData objDS = new DatasetData();
                ds = objDS.datasetAgainstReconData(objdatasetAgainstRecon, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

    }
}

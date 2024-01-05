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
		public static DataTable DatasettoReconRead(DatasettoReconmodellist DatasettoReconmodellist, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasettoRecondata objDS = new DatasettoRecondata();
				ds = objDS.DatasettoReconReaddata(DatasettoReconmodellist, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasettoReconprocess(DatasettoReconmodelprocess DatasettoReconmodelprocess, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasettoRecondata objDS = new DatasettoRecondata();
				ds = objDS.DatasettoReconprocessdata(DatasettoReconmodelprocess, headerval,constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable DatasettoManualRead(UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasettoRecondata objDS = new DatasettoRecondata();
				ds = objDS.DatasettoManualReaddata(headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

        public static DataSet ManuaMatchInfoService(ManualMatchinfoModel objManualMatchinfo, UserManagementModel.headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DatasettoRecondata objDS = new DatasettoRecondata();
                ds = objDS.ManuaMatchInfodata(objManualMatchinfo, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        //runManualfileService

        public static DataTable runManualfileService(runManualfileModel objrunManualfile, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                DatasettoRecondata objDS = new DatasettoRecondata();
                ds = objDS.runManualfiledata(objrunManualfile, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

		//runProcessdatasetService

		public static DataTable runProcessdatasetService(runProcessdatasetModel objrunProcessdataset, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasettoRecondata objDS = new DatasettoRecondata();
				ds = objDS.objrunProcessdatasetdata(objrunProcessdataset, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

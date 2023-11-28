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

		public static DataTable DatasettoManualRead(UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasettoRecondata objDS = new DatasettoRecondata();
				ds = objDS.DatasettoManualReaddata(headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}

        public static DataSet ManuaMatchInfoService(ManualMatchinfoModel objManualMatchinfo, UserManagementModel.headerValue headerval)
        {
            DataSet ds = new DataSet();
            try
            {
                DatasettoRecondata objDS = new DatasettoRecondata();
                ds = objDS.ManuaMatchInfodata(objManualMatchinfo, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }

        //runManualfileService

        public static DataTable runManualfileService(runManualfileModel objrunManualfile, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                DatasettoRecondata objDS = new DatasettoRecondata();
                ds = objDS.runManualfiledata(objrunManualfile, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

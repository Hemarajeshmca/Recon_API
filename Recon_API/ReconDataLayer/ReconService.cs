using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
using static ReconModels.ReconModel;
using static ReconModels.UserManagementModel;

namespace ReconServiceLayer
{
    public class ReconService
    {
        public static DataTable getReconType(UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recntypeData(headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable getReconList(Reconlist objreconlist, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recnlistData(objreconlist, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet fetchReconDetails(fetchRecon objfetch, UserManagementModel.headerValue headerval, string constring)
        {
            //DataTable ds = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.fetchRecondtl(objfetch, headerval, constring);

            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable recondatamapping(datamapping objdatamapping, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recondatamapping(objdatamapping, headerval, constring);

            }
            catch (Exception e)
            { }
            return ds;
        }


        public static DataTable Recon(Recon recon, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recon(recon, headerval, constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable Recondataset(Recondataset objrecondataset, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recondatset(objrecondataset, headerval, constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        
        public static DataTable Recondatamappinglist(getReconDataMappingList objdatamappinglist, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recondatamappinglist(objdatamappinglist, headerval, constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

		

		public static DataTable ReconFieldAgainstReconlist(getFieldAgainstReconList objfieldlist, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objrecon = new ReconData();
				ds = objrecon.ReconFieldAgainstReconlist(objfieldlist, headerval, constring);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ds;
		}

        public static DataTable reconlistknockoffService(UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.reconlistknockoff(headerval, constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

		public static DataTable getReconagainsttypecode(Reconagainsttypecode objreconlist, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.reconagainsttypecodeData(objreconlist, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		
		public static DataSet Datasetfield(Datasetfieldlist Datasetfieldlist, UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				ReconData objDS = new ReconData();
				ds = objDS.Datasetfielddata(Datasetfieldlist, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

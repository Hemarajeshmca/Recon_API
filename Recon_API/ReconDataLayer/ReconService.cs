using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ReconModel;

namespace ReconServiceLayer
{
    public class ReconService
    {
        public static DataTable getReconType(UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recntypeData(headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable getReconList(Reconlist objreconlist, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recnlistData(objreconlist, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet fetchReconDetails(fetchRecon objfetch, UserManagementModel.headerValue headerval)
        {
            //DataTable ds = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.fetchRecondtl(objfetch, headerval);

            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable recondatamapping(datamapping objdatamapping, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recondatamapping(objdatamapping, headerval);

            }
            catch (Exception e)
            { }
            return ds;
        }


        public static DataTable Recon(Recon recon, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recon(recon, headerval);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable Recondataset(Recondataset objrecondataset, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recondatset(objrecondataset, headerval);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        
        public static DataTable Recondatamappinglist(getReconDataMappingList objdatamappinglist, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recondatamappinglist(objdatamappinglist, headerval);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

		

		public static DataTable ReconFieldAgainstReconlist(getFieldAgainstReconList objfieldlist, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objrecon = new ReconData();
				ds = objrecon.ReconFieldAgainstReconlist(objfieldlist, headerval);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ds;
		}
	}
}

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
        public static DataTable getReconType()
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recntypeData();
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable getReconList(Reconlist objreconlist)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recnlistData(objreconlist);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet fetchReconDetails(fetchRecon objfetch)
        {
            //DataTable ds = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.fetchRecondtl(objfetch);

            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable recondatamapping(datamapping objdatamapping)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recondatamapping(objdatamapping);

            }
            catch (Exception e)
            { }
            return ds;
        }


        public static DataTable Recon(Recon recon)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recon(recon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}

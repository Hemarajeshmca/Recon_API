using Newtonsoft.Json;
using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconServiceLayer
{
    public class knockoffService
    {
        KnockOffData knockOffData = new KnockOffData();
        DataTable dt = new DataTable();
       
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(knockoffService));
        List<Dictionary<string, object>> returnObjForFetch = new List<Dictionary<string, object>>();

       

        public DataSet ReconMstTAcc(ReconMstTacc reconMstTacc)
        {
            try
            {
                DataSet ds = knockOffData.ReconMstTAcc(reconMstTacc);
               
                //  return retResult;
                return ds;

            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    
     public DataSet runReport(RunReport runReport)
        {
            try
            {
                DataSet ds = knockOffData.runReport(runReport);
                return ds;

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		//runkosummService

		public DataSet runkosummService(runkosumm objrunkosumm)
		{
			try
			{
				DataSet ds = knockOffData.runkosummData(objrunkosumm);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		//	recondatasetinfoService

		public DataSet recondatasetinfoService(recondatasetinfo objrecondatasetinfo)
		{
			try
			{
				DataSet ds = knockOffData.recondatasetinfoData(objrecondatasetinfo);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//runreportService

		public DataTable undorunreportService(runreportmodel objrunreport)
		{
			try
			{
				DataTable dt = knockOffData.undorunreportData(objrunreport);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//undoKOService

		public DataTable undoKOService(undoKOmodel objundoKO)
		{
			try
			{
				DataTable dt = knockOffData.undoKOData(objundoKO);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

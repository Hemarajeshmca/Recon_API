using Newtonsoft.Json;
using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static ReconModels.UserManagementModel;
using System.Threading.Tasks;

namespace ReconServiceLayer
{
    public class knockoffService
    {
        KnockOffData knockOffData = new KnockOffData();
        DataTable dt = new DataTable();
       
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(knockoffService));
        List<Dictionary<string, object>> returnObjForFetch = new List<Dictionary<string, object>>();

       

        public DataSet ReconMstTAcc(ReconMstTacc reconMstTacc, string constring)
        {
            try
            {
                DataSet ds = knockOffData.ReconMstTAcc(reconMstTacc, constring);
               
                //  return retResult;
                return ds;

            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    
     public DataSet runReport(RunReport runReport, string constring)
        {
            try
            {
                DataSet ds = knockOffData.runReport(runReport, constring);
                return ds;

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		//runkosummService

		public DataSet runkosummService(runkosumm objrunkosumm, string constring)
		{
			try
			{
				DataSet ds = knockOffData.runkosummData(objrunkosumm, constring);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		//	recondatasetinfoService

		public DataSet recondatasetinfoService(recondatasetinfo objrecondatasetinfo, string constring)
		{
			try
			{
				DataSet ds = knockOffData.recondatasetinfoData(objrecondatasetinfo, constring);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//runreportService

		public DataTable undorunreportService(runreportmodel objrunreport, string constring)
		{
			try
			{
				DataTable dt = knockOffData.undorunreportData(objrunreport, constring);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//undoKOService

		public DataTable undoKOService(undoKOmodel objundoKO, string constring)
		{
			try
			{
				DataTable dt = knockOffData.undoKOData(objundoKO, constring);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable undoKOjobService(undoKOjobModel objundoKO, string constring)
		{
			try
			{
				DataTable dt = knockOffData.undoKOjobData(objundoKO, constring);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable undomatchjobService(undomatchmodel objundoKO, string constring)
		{
			try
			{
				DataTable dt = knockOffData.undomatchjobData(objundoKO, constring);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		//getundojobruleService

		public DataSet getundojobruleService(getundojobrulemodel objgetundojobrule, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DataSet ds = knockOffData.getundojobruleData(objgetundojobrule, headerval, constring);
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

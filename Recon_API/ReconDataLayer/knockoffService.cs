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
        

        }
    }

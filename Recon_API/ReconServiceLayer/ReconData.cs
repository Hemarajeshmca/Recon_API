using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
using static ReconModels.ReconModel;

namespace ReconDataLayer
{
    public class ReconData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        DBManager dbManager = new DBManager("ConnectionString");
        List<IDbDataParameter>? parameters;
        public DataTable recntypeData()
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                ds = dbManager.execStoredProcedure("pr_get_recontype", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }


        public DataTable recnlistData(Reconlist objreconlist)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", objreconlist.in_user_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_recon_mst_trecon_list", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    
    
       public DataSet fetchRecondtl(fetchRecon objfetch)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objfetch.in_recon_code, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_fetch_recondetails", CommandType.StoredProcedure, parameters.ToArray());
                             
                ds.Tables[0].TableName = "ReconHeader";
                ds.Tables[1].TableName = "ReconDataSet";

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
    }
}

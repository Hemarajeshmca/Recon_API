using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public DataTable recondatamapping(datamapping objdatamapping)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reconfield_gid", objdatamapping.in_reconfield_gid, DbType.Int16));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objdatamapping.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_field_name", objdatamapping.in_recon_field_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_display_order", objdatamapping.in_display_order, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_dataset_code", objdatamapping.in_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_field_name", objdatamapping.in_dataset_field_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objdatamapping.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objdatamapping.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", objdatamapping.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_trn_trecondatamapping", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }


        public DataTable Recon(Recon recon)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_gid", recon.in_recon_gid, DbType.Int16, ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_recon_code", recon.in_recon_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recon_name", recon.in_recon_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recontype_code", recon.in_recontype_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recon_automatch_partial", recon.in_recon_automatch_partial, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_period_from", recon.in_period_from, DbType.Date));

                parameters.Add(dbManager.CreateParameter("in_period_to", recon.in_period_to, DbType.Date));

                parameters.Add(dbManager.CreateParameter("in_until_active_flag", recon.in_until_active_flag, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", recon.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", recon.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", recon.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_trecon", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}

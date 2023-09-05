using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.UserManagementModel;

namespace ReconDataLayer
{
    public class UserManagementData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        DBManager dbManager = new DBManager("ConnectionString");
        List<IDbDataParameter> parameters;
        public DataTable Loginvalidation(Login_model Objmodel)
        {
            try
            {
                //Recon.Controllers.LogHelper.WriteLog("UserName" + Objmodel.user_name, "Login_datamodel");
                //Recon.Controllers.LogHelper.WriteLog("UserID" + Objmodel.user_id, "Login_datamodel");
                //Recon.Controllers.LogHelper.WriteLog("Password" + Objmodel.password, "Login_datamodel");
                Dictionary<string, Object> values = new Dictionary<string, object>();

                MySqlDataAccess con = new MySqlDataAccess(Objmodel.user_id);
               
                    parameters = new List<IDbDataParameter>();

                    parameters.Add(dbManager.CreateParameter("in_user_code", Objmodel.user_id, DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_password", Objmodel.password, DbType.String));

                    parameters.Add(dbManager.CreateParameter("in_ip_addr", Objmodel.ip, DbType.String));
                    ds = dbManager.execStoredProcedure("pr_get_loginvalidation_new", CommandType.StoredProcedure, parameters.ToArray());
                    result = ds.Tables[0];
                    return result;

            }
            catch (Exception ex)
            {

                //string method_name = (new StackTrace()).GetFrame(0).GetMethod().Name;
                //string source_name = this.GetType().ToString();
                //string error = ex.ToString();
                //Recon.Controllers.LogHelper.WriteLog("catchdatamodel" + error, "Login_datamodel");
                //MSQLCON con = new MSQLCON(Objmodel.ip, Objmodel.user_id);
                //con.errorlog(Objmodel.ip, Objmodel.user_id, method_name, error, source_name);
                return result;
            }
        }
    }
}

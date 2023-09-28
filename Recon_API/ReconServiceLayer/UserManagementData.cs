using Org.BouncyCastle.Asn1.Ocsp;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.UserManagementModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ReconDataLayer
{
    public class UserManagementData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        DBManager dbManager = new DBManager("ConnectionStrings");
        List<IDbDataParameter> parameters;
        public DataTable Loginvalidation(Login_model Objmodel)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("ConnectionStrings");
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
                return result;
            }
        }

        public DataTable changepass_save(change_password Usermodel, headerValue hv)
        {
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess(Usermodel.user_id);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_gid", hv.userCode, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_old_password", Usermodel.old_password, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_new_password", Usermodel.new_password, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_set_password", CommandType.StoredProcedure, parameters.ToArray());
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

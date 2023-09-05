using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReconDataLayer;

namespace ReconServiceLayer
{
    public class UserManagementService
    {
        public class login_serivce
        {
            public static DataTable Loginvalidation(UserManagementModel.Login_model objmodel)
            {
                DataTable ds = new DataTable();
                try
                {
                    UserManagementData objproduct = new UserManagementData();
                    ds = objproduct.Loginvalidation(objmodel);
                }
                catch (Exception e)
                {
                    //Recon.Controllers.LogHelper.WriteLog("Catch Service" + e.ToString(), "LoginService");
                }
                return ds;
            }

            //public static string[] changepass_save(User_model objmodel)
            //{
            //    string[] result = { };
            //    DataTable tab = new DataTable();
            //    User_model user = new User_model();
            //    try
            //    {
            //        Login_datamodel objproduct1 = new Login_datamodel();
            //        result = objproduct1.changepass_save(objmodel);
            //        if (result.Length == 2)
            //        {
            //            user.result = Convert.ToInt32(result[1]);
            //            user.msg = result[0];
            //        }
            //        else
            //        {
            //            user.result = 0;
            //            user.msg = "Process Failed";
            //        }

            //        return result;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            //public static DataTable forgotpassword(Login_model objmodel)
            //{
            //    DataTable ds = new DataTable();
            //    Login_datamodel objproduct = new Login_datamodel();
            //    ds = objproduct.forgotpassword(objmodel);
            //    return ds;
            //}
        }
    }
}

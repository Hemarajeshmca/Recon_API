﻿using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReconDataLayer;
using static ReconModels.UserManagementModel;

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
                { }
                return ds;
            }

            public static DataTable changepass_save(UserManagementModel.change_password objmodel, UserManagementModel.headerValue headerval)
            {
                Login_model user = new Login_model();
                DataTable ds = new DataTable();
                try
                {
                    UserManagementData objproduct = new UserManagementData();
                    ds = objproduct.changepass_save(objmodel, headerval);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //dashboardService

            public static DataSet dashboardService(UserManagementModel.dashboardmodel objdashboard, UserManagementModel.headerValue headerval)
            {
                Login_model user = new Login_model();
                DataSet ds = new DataSet();
                try
                {
                    UserManagementData objproduct = new UserManagementData();
                    ds = objproduct.dashboardData(objdashboard, headerval);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}

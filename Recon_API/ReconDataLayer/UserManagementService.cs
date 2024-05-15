using ReconModels;
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
            public static DataTable Loginvalidation(UserManagementModel.Login_model objmodel, string constring)
            {
                DataTable ds = new DataTable();
                try
                {
                    UserManagementData objproduct = new UserManagementData();
                    ds = objproduct.Loginvalidation(objmodel, constring);
                }
                catch (Exception e)
                { }
                return ds;
            }

            public static DataTable changepass_save(UserManagementModel.change_password objmodel, UserManagementModel.headerValue headerval, string constring)
            {
                Login_model user = new Login_model();
                DataTable ds = new DataTable();
                try
                {
                    UserManagementData objproduct = new UserManagementData();
                    ds = objproduct.changepass_save(objmodel, headerval, constring);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //dashboardService

            public static DataSet dashboardService(UserManagementModel.dashboardmodel objdashboard, UserManagementModel.headerValue headerval, string constring)
            {
                Login_model user = new Login_model();
                DataSet ds = new DataSet();
                try
                {
                    UserManagementData objproduct = new UserManagementData();
                    ds = objproduct.dashboardData(objdashboard, headerval, constring);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
			public static DataTable userlist_srv(UserManagementModel.headerValue objmodel, string constring)
			{
				DataTable ds = new DataTable();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					ds = objproduct.userlist_db(objmodel, constring);
				}
				catch (Exception e)
				{ }
				return ds;
			}
			public List<treeviewllist> treeviewlist_srv(UserManagementModel.headerValue objmodel, string constring)
			{
				List<treeviewllist> tnl = new List<treeviewllist>();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					tnl = objproduct.treeviewlist_db(objmodel, constring);
				}
				catch (Exception e)
				{ }
				return tnl;
			}
			public static DataTable Usersave_srv(UserManagementModel.User_model objmodel, UserManagementModel.headerValue headerval, string constring)
			{
				DataTable ds = new DataTable();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					ds = objproduct.Usersave_db(objmodel, headerval, constring);
				}
				catch (Exception e)
				{ }
				return ds;
			}
			public static DataTable Usermappingsave_srv(UserManagementModel.usermappingmodel objmodel, UserManagementModel.headerValue headerval, string constring)
			{
				DataTable ds = new DataTable();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					ds = objproduct.Usermappingsave_db(objmodel, headerval, constring);
				}
				catch (Exception e)
				{ }
				return ds;
			}
			public static DataTable getcheckednode_srv(UserManagementModel.getcheckedmodel objmodel, UserManagementModel.headerValue headerval, string constring)
			{
				DataTable ds = new DataTable();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					ds = objproduct.getcheckednode_db(objmodel, headerval, constring);
				}
				catch (Exception e)
				{ }
				return ds;
			}
			public static DataTable setcontextlist_srv(UserManagementModel.getcheckedmodel objmodel, UserManagementModel.headerValue headerval, string constring)
			{
				DataTable ds = new DataTable();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					ds = objproduct.setcontextlist_db(objmodel, headerval, constring);
				}
				catch (Exception e)
				{ }
				return ds;
			}
			public static DataTable applycontextlist_srv(UserManagementModel.setcontextmodel objmodel, UserManagementModel.headerValue headerval, string constring)
			{
				DataTable ds = new DataTable();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					ds = objproduct.applycontextlist_db(objmodel, headerval, constring);
				}
				catch (Exception e)
				{ }
				return ds;
			}
			public static DataTable getcontextlist_srv(UserManagementModel.getcontexttmodel objmodel, UserManagementModel.headerValue headerval, string constring)
			{
				DataTable ds = new DataTable();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					ds = objproduct.getcontextlist_db(objmodel, headerval, constring);
				}
				catch (Exception e)
				{ }
				return ds;
			}
			public static DataSet getmenulist_srv(UserManagementModel.getmenumodel objmodel, UserManagementModel.headerValue headerval, string constring)
			{
				DataSet ds = new DataSet();
				try
				{
					UserManagementData objproduct = new UserManagementData();
					ds = objproduct.getmenulist_db(objmodel, headerval, constring);
				}
				catch (Exception e)
				{ }
				return ds;
			}
            public static DataTable lastsession_srv(UserManagementModel.getmenumodel1 objmodel, UserManagementModel.headerValue headerval, string constring)
            {
                DataTable ds = new DataTable();
                try
                {
                    UserManagementData objproduct = new UserManagementData();
                    ds = objproduct.lastsession_db(objmodel, headerval, constring);
                }
                catch (Exception e)
                { }
                return ds;
            }
            
        }
    }
}

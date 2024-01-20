using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.CommonModel;
using static ReconModels.RolesModel;

namespace ReconServiceLayer
{
	public class RolesService
	{
		public static DataTable rolelistService(rolelistModel objrolelist, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RolesData objDS = new RolesData();
				ds = objDS.rolelistData(objrolelist, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//roleService

		public static DataTable roleService(UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RolesData objDS = new RolesData();
				ds = objDS.roleData(headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//RolefetchService

		public static DataTable RolefetchService(RolefetchModel objRolefetchModel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RolesData objDS = new RolesData();
				ds = objDS.RolefetchData(objRolefetchModel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//RoledetailsService
		public static DataTable RoledetailsService(roledetailsModel objroledetailsModel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RolesData objDS = new RolesData();
				ds = objDS.RoledetailsData(objroledetailsModel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//saveRoleAccessService
		public static DataTable saveRoleAccessService(saveRoleAccessModel objsaveRoleAccessModel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RolesData objDS = new RolesData();
				ds = objDS.saveRoleAccessData(objsaveRoleAccessModel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

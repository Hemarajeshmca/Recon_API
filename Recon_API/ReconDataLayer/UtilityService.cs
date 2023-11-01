using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.UtilityModel;


namespace ReconServiceLayer
{
	public class UtilityService
	{
		public static DataTable getJobStatusList(JobStatusList objobstatus, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				UtilityData objutility = new UtilityData();
				ds = objutility.jobstatusData(objobstatus, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable getJobtypeList(UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				UtilityData objutility = new UtilityData();
				ds = objutility.jobtypeData(headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

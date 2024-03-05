using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
using static ReconModels.theme_model;

namespace ReconServiceLayer
{
	public class theme_service
	{
		public static DataTable themeRead(UserManagementModel.headerValue headerval, themelistmodel list, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themeReaddata(headerval, list, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable themeHeader(themeHeadermodel themeHeadermodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themeHeaderdata(themeHeadermodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable themedetail(themedetailmodel themedetailmodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themedetaildata(themedetailmodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataSet themedetail(themeDetailmodel themeDetailmodel,UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themedetaildata(themeDetailmodel,headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

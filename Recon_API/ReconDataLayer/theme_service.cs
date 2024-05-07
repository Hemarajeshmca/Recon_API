using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;
using static ReconModels.ReconModel;
using static ReconModels.RulesetupModel;
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
		public static DataSet themedetailfetch(themeDetailmodelfetch themeDetailmodel,UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themedetaildatafetch(themeDetailmodel,headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		
		public static DataTable ThemeCondition(ThemeCondition objthemeCondition, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.ThemeConditionData(objthemeCondition, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable themegrouping(themegrouping objthemegrouping, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themegroupingData(objthemegrouping, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable themeaggfunsrv(Aggfunction objAggfunction, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themeaggfunData(objAggfunction, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getConditioncriteria(getConditiontheme objcondition, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.getConditioncriteriaData(objcondition, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable themeaggconditionsrv(Aggcondition objAggcondition, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themeaggconditionData(objAggcondition, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getdataagainsReconthemesrv(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.getdataagainsReconthemeData(objdatarecon, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable themelistclonesrv(UserManagementModel.headerValue headerval, themelistmodel list, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				themedata objDS = new themedata();
				ds = objDS.themelistclonedata(headerval, list, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable clonethemeService(clonethemeModel objclonetheme, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable dt = new DataTable();
			try
			{
				themedata objDS = new themedata();
				dt = objDS.clonethemeData(objclonetheme, headerval, constring);
			}
			catch (Exception e)
			{ }
			return dt;
		}
	}
}

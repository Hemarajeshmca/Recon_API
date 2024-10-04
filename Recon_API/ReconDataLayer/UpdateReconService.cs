using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.UpdateReconModel;

namespace ReconServiceLayer
{
	public class UpdateReconService
	{
		public static DataTable ReconUpdateRuleService(ReconUpdateRuleModel objReconUpdateRule, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UpdateReconData objqcd = new UpdateReconData();
				ds = objqcd.ReconUpdateRuleData(objReconUpdateRule, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable ReconUpdatePreprocessService(ReconUpdatePreprocessModel objReconUpdatePreprocess, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UpdateReconData objqcd = new UpdateReconData();
				ds = objqcd.ReconUpdatePreprocessData(objReconUpdatePreprocess, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable ReconUpdateThemeService(ReconUpdateThemeModel objReconUpdateTheme, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UpdateReconData objqcd = new UpdateReconData();
				ds = objqcd.ReconUpdateThemeData(objReconUpdateTheme, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//ReconagainstRuleService

		public static DataTable ReconagainstRuleService(ReconagainstRuleModel objReconagainstRule, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UpdateReconData objqcd = new UpdateReconData();
				ds = objqcd.ReconagainstRuleData(objReconagainstRule, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		//ReconagainstPreProcessService
		public static DataTable ReconagainstPreProcessService(ReconagainstPreProcessModel objReconagainstPreProcess, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UpdateReconData objqcd = new UpdateReconData();
				ds = objqcd.ReconagainstPreProcessData(objReconagainstPreProcess, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		//ReconagainstThemeService
		public static DataTable ReconagainstThemeService(ReconagainstThemeModel objReconagainstTheme, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UpdateReconData objqcd = new UpdateReconData();
				ds = objqcd.ReconagainstThemeData(objReconagainstTheme, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

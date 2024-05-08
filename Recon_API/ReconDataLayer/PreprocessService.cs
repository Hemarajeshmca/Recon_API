using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.PreprocessModel;
using static ReconModels.ReconModel;
using static ReconModels.RulesetupModel;
using static ReconModels.theme_model;

namespace ReconServiceLayer
{
    public class PreprocessService
    {
        public static DataTable getPreprocessList(Preprocesslistmodel objpreprocess,UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                PreprocessData objqcd = new PreprocessData();
                ds = objqcd.getPreprocessListData(objpreprocess,headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
		public static DataTable preprocessHeader(preprocessHeadermodel preprocessHeadermodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				PreprocessData objDS = new PreprocessData();
				ds = objDS.preprocessHeaderdata(preprocessHeadermodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable preprocessfiltersrv(filterdata objfilterdata, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				PreprocessData objDS = new PreprocessData();
				ds = objDS.preprocessfilterData(objfilterdata, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataSet getPreprocessfetch(Preprocessfetchmodel objpreprocessfetch, UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				PreprocessData objqcd = new PreprocessData();
				ds = objqcd.getPreprocessfetchData(objpreprocessfetch, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable preprocessconditionsrv(conditiondata objconditiondata, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				PreprocessData objDS = new PreprocessData();
				ds = objDS.preprocessconditionData(objconditiondata, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable Validatequerysrv(Validatequerymodel objValidatequerymodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				PreprocessData objqcd = new PreprocessData();
				ds = objqcd.ValidatequeryData(objValidatequerymodel, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getConditionlookupsrv(getConditionlook objcondition, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				PreprocessData objrule = new PreprocessData();
				ds = objrule.getConditionlookupData(objcondition, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getPreprocessListclonesrv(Preprocesslistmodelclone objpreprocess, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				PreprocessData objqcd = new PreprocessData();
				ds = objqcd.getPreprocessListclonedata(objpreprocess, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable clonepreprocessService(clonepreprocessModel objclonepreprocess, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable dt = new DataTable();
			try
			{
				PreprocessData objqcd = new PreprocessData();
				dt = objqcd.clonepreprocessData(objclonepreprocess, headerval, constring);
			}
			catch (Exception e)
			{ }
			return dt;
		}
		public static DataTable getdatasetReconPreprocesssrv(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				PreprocessData objqcd = new PreprocessData();
				ds = objqcd.getdatasetReconPreprocessdata(objdatarecon, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}

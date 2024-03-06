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
	}
}

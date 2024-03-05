using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ReconModel;

namespace ReconServiceLayer
{
    public class PreprocessService
    {
        public static DataTable getPreprocessList(UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                PreprocessData objqcd = new PreprocessData();
                ds = objqcd.getPreprocessListData(headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.CommonModel;
using static ReconModels.DatasetModel;
using ReconDataLayer;

namespace ReconServiceLayer
{
	public class CommonService
	{
		public static DataTable Commonservice(errorlogModel objerrorlog, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				CommonHeader objDS = new CommonHeader();
				ds = objDS.commonData(objerrorlog);
			}
			catch (Exception e)
			{ }
			return ds;
		}



        public static DataTable configvalueservice(configvalueModel objconfigvalue, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                CommonHeader objDS = new CommonHeader();
                ds = objDS.configvalueData(objconfigvalue);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }

}

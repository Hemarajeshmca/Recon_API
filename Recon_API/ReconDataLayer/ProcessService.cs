using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ProcessModel;

namespace ReconServiceLayer
{
    public class ProcessService
    {
        public static DataTable automatchpreviewservice(automatchpreviewmodel objautomatchpreview, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ProcessData objprocess = new ProcessData();
                ds = objprocess.automatchpreviewData(objautomatchpreview, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable undokojobservice(undokojobmodel objundokojobmodel, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ProcessData objprocess = new ProcessData();
                ds = objprocess.undokojobData(objundokojobmodel, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }

        //undokoservice
        public static DataTable undokoservice(undokomodel objundokomodel, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                ProcessData objprocess = new ProcessData();
                ds = objprocess.objundokoData(objundokomodel, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

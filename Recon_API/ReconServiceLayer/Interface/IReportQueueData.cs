using ReconModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ReconDataLayer.Interface
{
    public interface IReportQueueData
    {

        public DataTable setReportqueuedata(ReportQueueModel.reportqueue report, string jsonString, UserManagementModel.headerValue headerVal);
        public DataTable getReportqueuedata(UserManagementModel.headerValue headerVal);
    }
}

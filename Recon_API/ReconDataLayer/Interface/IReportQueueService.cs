using ReconModels;
using System.Data;

namespace ReconServiceLayer.Interface
{
    public interface IReportQueueService
    {
        public DataTable setReportqueueservice(ReportQueueModel.reportqueue report, string jsonString, UserManagementModel.headerValue headerVal);
        public DataTable getReportqueueservice(UserManagementModel.headerValue headerVal);
    }
}

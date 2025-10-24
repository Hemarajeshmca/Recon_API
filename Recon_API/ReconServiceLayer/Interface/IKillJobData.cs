using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconDataLayer.Interface
{
    public interface IKillJobData
    {
        public DataTable setKillJobData(Int64 processId, string action, UserManagementModel.headerValue headerVal);
        public DataTable getKillJobData(Int64 processId, string action, UserManagementModel.headerValue headerVal);
    }
}

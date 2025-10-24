using ReconDataLayer;
using ReconDataLayer.Interface;
using ReconModels;
using ReconServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ResultSetModel;

namespace ReconServiceLayer
{
    public class KillJobService : IKillJobService
    {
        DataTable dt = new DataTable();
        private readonly IKillJobData _killJobData;

        public KillJobService(IKillJobData killJobData)
        {
            _killJobData = killJobData;
        }

        public DataTable setKillJobService(Int64 processId, string action, UserManagementModel.headerValue headerVal)
        {
            try
            {
                dt = _killJobData.setKillJobData(processId, action, headerVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable getKillJobService(Int64 processId, string action, UserManagementModel.headerValue headerVal)
        {
            try
            {
                dt = _killJobData.getKillJobData(processId, action, headerVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}

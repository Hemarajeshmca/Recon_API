using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconDataLayer
{
    public class KnockOffData
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public List<IDbDataParameter> parameters;
        public DBManager dbManager = new DBManager("ConnectionString");
        

       // private readonly YourDbContext _context;


       


        public DataSet ReconMstTAcc(ReconMstTacc reconMstTacc)
        {
            try
            {
                parameters = new List<IDbDataParameter>();
                
                parameters.Add(dbManager.CreateParameter("in_acc_gid", reconMstTacc.in_acc_gid, DbType.Int16,ParameterDirection.InputOutput));

                parameters.Add(dbManager.CreateParameter("in_acc_code", reconMstTacc.in_acc_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_name", reconMstTacc.in_acc_name, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_category", reconMstTacc.in_acc_category, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_acc_responsibility", reconMstTacc.in_acc_responsibility, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action", reconMstTacc.in_action, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_action_by", reconMstTacc.in_action_by, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_active_status", reconMstTacc.in_active_status, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result","out" , DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_tacc", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet runReport(RunReport runReport)
        {
            try
            {
                parameters = new List<IDbDataParameter>();
               
                parameters.Add(dbManager.CreateParameter("in_report_code", runReport.in_report_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_recon_gid", runReport.in_recon_gid, DbType.Int16));

                parameters.Add(dbManager.CreateParameter("in_condition", runReport.in_condition, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_ip_addr", runReport.in_ip_addr, DbType.String));

                parameters.Add(dbManager.CreateParameter("in_outputfile_flag", runReport.in_outputfile_flag, DbType.Boolean));

                parameters.Add(dbManager.CreateParameter("in_user_code", runReport.in_user_code, DbType.String));

                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String,ParameterDirection.Output));

                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String,ParameterDirection.Output));

               
                ds = dbManager.execStoredProcedure("pr_run_report", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


		//runkosummData
		public DataSet runkosummData(runkosumm objrunkosumm)
		{
			try
			{
				parameters = new List<IDbDataParameter>();

				parameters.Add(dbManager.CreateParameter("in_recon_code", objrunkosumm.in_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_period_from", objrunkosumm.in_period_from, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_period_to", objrunkosumm.in_period_to, DbType.Date));
				parameters.Add(dbManager.CreateParameter("in_ip_addr", objrunkosumm.in_ip_addr, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objrunkosumm.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedurelist("pr_get_kosumm", CommandType.StoredProcedure, parameters.ToArray());
				return ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

	}
}


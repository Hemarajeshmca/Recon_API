using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.CommonModel;
using static ReconModels.DatasetModel;

namespace ReconDataLayer
{
    public class CommonHeader
    {
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter>? parameters;

		public DataTable commonData(errorlogModel objerrorlog, UserManagementModel.headerValue headerval)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_ip_addr", objerrorlog.in_ip_addr, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_source_name", objerrorlog.in_source_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_errorlog_text", objerrorlog.in_errorlog_text, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_proc_name", objerrorlog.in_proc_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_ins_errorlog", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}

	}
}
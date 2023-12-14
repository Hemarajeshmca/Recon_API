using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.CommonModel;
using static ReconModels.DatasetModel;
using static ReconModels.UserManagementModel;

namespace ReconDataLayer
{
    public class CommonHeader
    {
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter>? parameters;

		public DataTable commonData(errorlogModel objerrorlog)
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
                parameters.Add(dbManager.CreateParameter("in_user_code", objerrorlog.user_code, DbType.String));
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

        public void logger(string sMessage)
        {
            string logFilePath = "D:\\recon_logger\\error.log"; // "D:\\DMS Error Log\\error.log";

            string[] parts = sMessage.Split(new string[] { "SP:", "Message:" }, StringSplitOptions.None);
            string result = parts[1].Trim();
            errorlogModel objmodel = new errorlogModel();
            objmodel.in_proc_name = parts[1].Trim();
            objmodel.in_errorlog_text = parts[2].Trim();
            objmodel.in_ip_addr = "localhost";
            objmodel.in_source_name = "SP";
            objmodel.user_code = "Hema";
            commonData(objmodel);
            // Ensure the directory exists
            string logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Append the error information to the log file
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Timestamp: {DateTime.Now}");

                writer.WriteLine($"Message: {sMessage}");
                writer.WriteLine(new string('-', 40)); // Separator between entries
            }
        }

    }
}
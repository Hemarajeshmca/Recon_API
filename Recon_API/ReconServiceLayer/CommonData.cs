﻿using DocumentFormat.OpenXml.Drawing.Diagrams;
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
		List<IDbDataParameter>? parameters;
        string constring1 = "";
		public DataTable commonData(errorlogModel objerrorlog, string constring)
		{
			try
			{
				constring1= constring;
				DBManager dbManager = new DBManager(constring);
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

        public void logger_old(string sMessage)
        {
            string logFilePath = "D:\\recon_logger\\error.log";

            string[] parts = sMessage.Split(new string[] { "SP:", "Message:" }, StringSplitOptions.None);
            string result = parts[1].Trim();
            errorlogModel objmodel = new errorlogModel();
            objmodel.in_proc_name = parts[1].Trim();
            objmodel.in_errorlog_text = parts[2].Trim();
            objmodel.in_ip_addr = "localhost";
            objmodel.in_source_name = "SP";
            objmodel.user_code = "Hema";
            commonData(objmodel, constring1);
            string logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Timestamp: {DateTime.Now}");
                writer.WriteLine($"Message: {sMessage}");
                writer.WriteLine(new string('-', 40)); 
            }

        }

		public void logger(string sMessage)
		{
            string log_folderpath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Errorlog");
            string errorlogfilePath = log_folderpath + '/' + "error_log.txt";
            if (!Directory.Exists(log_folderpath))
            {
                Directory.CreateDirectory(log_folderpath);
            }
            using (StreamWriter writer = new StreamWriter(errorlogfilePath, true))
            {
                writer.WriteLine($"Timestamp: {DateTime.Now}");
                writer.WriteLine($"Message: {sMessage}");
                writer.WriteLine(new string('-', 40));
            }
        }

        //configvalueData
        public DataTable configvalueData(configvalueModel objconfigvalue, headerValue hv, string constring)
        {
            try
            {
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_config_name", objconfigvalue.in_config_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_config_value", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_get_configvalue", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                logger("SP:pr_get_configvalue" + " " + "Error Message:" + ex.Message);
                return result;
            }
        }
		public DataTable roleconfig_db(roleconfig objconfigvalue, headerValue hv, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_screen_code", objconfigvalue.in_screen_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", hv.role_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_role_config", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				logger("SP:pr_get_role_config" + " " + "Error Message:" + ex.Message);
				return result;
			}
		}

		public DataTable commonDataapi(string ipaddr,string sourcename,string errorlog,string procname,string usrcode,string constring)
		{
			try
			{
				constring1 = constring;
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_ip_addr", ipaddr, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_source_name", sourcename, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_errorlog_text", errorlog, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_proc_name", procname, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", usrcode, DbType.String));
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
		public DataTable reconmindate_db(reconmindate objconfigvalue, headerValue hv, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_recon_code", objconfigvalue.in_recon_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_recon_mindate", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				logger("SP:pr_get_recon_mindate" + " " + "Error Message:" + ex.Message);
				return result;
			}
		}
	}
}
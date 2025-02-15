using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ReconModels.UserManagementModel;

namespace ReconDataLayer
{
    public class DBManager
    {
        private DatabaseHandlerFactory dbFactory;
        private IDatabaseHandler database;
        private string providerName;
        DataTable outParameterTable= new DataTable();
        private readonly IConfiguration _configuration;
        public DBManager(string connectionStringName)
        {
            dbFactory = new DatabaseHandlerFactory(connectionStringName);
            database = dbFactory.CreateDatabase();
            providerName = dbFactory.GetProviderName();
        }

        public IDbConnection GetDatabasecOnnection()
        {
            return database.CreateConnection();
        }

        public void CloseConnection(IDbConnection connection)
        {
            database.CloseConnection(connection);
        }

        public IDbDataParameter CreateParameter(string name, object value, DbType dbType)
        {
            return DataParameterManager.CreateParameter(providerName, name, value, dbType, ParameterDirection.Input);
        }

        public IDbDataParameter CreateParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return DataParameterManager.CreateParameter(providerName, name, value, dbType, direction);
        }

        private void dberror(string spname, string errormsg)
        {
            var connstring = "Data Source = 146.56.55.230; UserID = root; Password = Flexi@123; Database = recon_flexi_poc; Port = 3306; SslMode = None";
            using (MySqlConnection connect = new MySqlConnection(connstring))
            {
                connect.Open();
                using (MySqlCommand command = connect.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "pr_ins_errorlog";

                    command.Parameters.AddWithValue("in_ip_addr", "localhost");
                    command.Parameters.AddWithValue("in_source_name", "");
                    command.Parameters.AddWithValue("in_errorlog_text", errormsg);
                    command.Parameters.AddWithValue("in_proc_name", spname);
                    command.Parameters.AddWithValue("in_user_code", "Hema");
                    MySqlParameter out_msg = new MySqlParameter("@out_msg", MySqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    MySqlParameter out_result = new MySqlParameter("@out_result", MySqlDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(out_msg);
                    command.Parameters.Add(out_result);
                    command.ExecuteNonQuery();
                }
            }

        }
       
       public DataSet execStoredProcedure(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null)
        {
            var dynamicData = new Dictionary<string, object>();            
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
							command.CommandTimeout = 0;
						}
                    }
                    var dataset = new DataSet();
                    var dataAdaper = database.CreateAdapter(command);					
					dataAdaper.Fill(dataset);
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            if (parameter != null && (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput))
                            {
                                dynamicData.Add(parameter.ParameterName, parameter.Value);
                            }
                        }
                    }
                    outParameterTable=ConvertDictionaryToDataTable(dynamicData);
                    outParameterTable.TableName = "outparam";                   
                    dataset.Tables.Add(outParameterTable);                  
                    return dataset;
                }
            }
        }

        public DataSet execStoredProcedurelist_old(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null)
        {
            var dynamicData = new Dictionary<string, object>();
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
							command.CommandTimeout = 0;
						}
                    }

                    var dataset = new DataSet();
                    var dataAdaper = database.CreateAdapter(command);
                    dataAdaper.Fill(dataset);
                    return dataset;
                }
            }
        }
        public DataSet execStoredProcedurelist(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null)
        {
            var dynamicData = new Dictionary<string, object>();
            try
            {
                using (var connection = database.CreateConnection())
                {
                    connection.Open();
                    using (var command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                            command.CommandTimeout = 0;
                        }
                        var dataset = new DataSet();
                        var dataAdaper = database.CreateAdapter(command);
                        dataAdaper.Fill(dataset);
                       
                        return dataset;
                    }
                }
            }
            catch (Exception ex)
            {
                dberror("API", ex.Message);
                CommonHeader objlog = new CommonHeader();
                objlog.logger("Error: " + "Error Message:" + ex.Message);
                string log_folderpath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Errorlog");
                string errorlogfilePath = log_folderpath + '/' + "error_log.txt";
                if (!Directory.Exists(log_folderpath))
                {
                    Directory.CreateDirectory(log_folderpath);
                }
                using (StreamWriter writer = new StreamWriter(errorlogfilePath, true))
                {
                    writer.WriteLine($"Timestamp: {DateTime.Now}");
                    writer.WriteLine($"Message: {ex.Message}");
                    writer.WriteLine(new string('-', 40));
                }
                throw;
            }
        }
        public DataTable ConvertDictionaryToDataTable(System.Collections.Generic.Dictionary<string, object> dictionary)
        {
            DataTable dataTable = new DataTable();
            foreach (var key in dictionary.Keys)
            {
                dataTable.Columns.Add(key, dictionary[key].GetType());
            }
            DataRow row = dataTable.NewRow();
            foreach (var key in dictionary.Keys)
            {
                row[key] = dictionary[key];
            }
            dataTable.Rows.Add(row);
            return dataTable;
        }        
    }
}


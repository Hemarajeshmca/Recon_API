using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconDataLayer
{
    public class DatabaseHandlerFactory
    {
        private IConfiguration _configuration;
        private string connectionString;

        public DatabaseHandlerFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DatabaseHandlerFactory(string connectionStringName)
        {
            connectionString = "Data Source = 146.56.55.230; UserID = root; Password = Flexi@123; Database = recon_bikebazaar; Port = 3306; SslMode = None";
        }

        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler database = null;

            database = new MySqlDataAccess(connectionString);

            return database;
        }

        public string GetProviderName()
        {
            return "MySql.Data.MySqlClient";
        }
    }
}

using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconDataLayer
{
    public class SupportingFileData
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public List<IDbDataParameter> parameters;
        public DBManager dbManager = new DBManager("ConnectionString");


        
    }
}

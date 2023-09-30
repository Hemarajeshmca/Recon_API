using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;

namespace ReconDataLayer
{
	public class DatasetData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter>? parameters;
		public DataTable DatasetReaddata(Datasetlistmodel Objmodel)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();			
				parameters.Add(dbManager.CreateParameter("in_user_gid", Objmodel.in_user_gid, DbType.Int32));
				parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.in_active_status, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_Dataset", CommandType.StoredProcedure, parameters.ToArray());
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

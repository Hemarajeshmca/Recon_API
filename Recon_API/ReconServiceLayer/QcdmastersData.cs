using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.QcdmasterModel;
using ReconModels;

namespace ReconDataLayer
{
	public class QcdmastersData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter> parameters;
		public DataTable QcdModeldataRead(QcdmasterModel Objmodel)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess(Objmodel.in_user_code);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", "", DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_qcdparent", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}
	
		public DataTable QcdModeldataGridRead(Qcdgridread objgridread)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess(objgridread.in_user_code);
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", objgridread.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_master_code", objgridread.in_master_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_qcdmaster", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				return result;
			}
		}

		public DataTable QcdMaster(mainQCDMaster objmaster)
		{
			try
			{
				Dictionary<string, Object> values = new Dictionary<string, object>();
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_master_gid", objmaster.masterGid, DbType.Int64));
				parameters.Add(dbManager.CreateParameter("in_master_syscode", objmaster.masterSyscode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_master_code", objmaster.masterCode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_master_short_code", objmaster.masterShortCode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_master_name", objmaster.masterName, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_master_multiple_name", objmaster.mastermutiplename, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_parent_master_syscode", objmaster.ParentMasterSyscode, DbType.String)); 
				parameters.Add(dbManager.CreateParameter("in_active_status", objmaster.active_status, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_action", objmaster.action, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_mst_tmaster", CommandType.StoredProcedure, parameters.ToArray());
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

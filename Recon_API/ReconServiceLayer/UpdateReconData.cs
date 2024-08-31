using Newtonsoft.Json;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ReconModel;
using static ReconModels.UpdateReconModel;

namespace ReconDataLayer
{

	public class UpdateReconData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		List<IDbDataParameter>? parameters;

		public DataTable ReconUpdateRuleData(ReconUpdateRuleModel objReconUpdateRule, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_base_recon_code", objReconUpdateRule.in_base_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_base_rule_code", objReconUpdateRule.in_base_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_update_recon_code", objReconUpdateRule.in_update_recon_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_update_rule_code", objReconUpdateRule.in_update_rule_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objReconUpdateRule.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_recon_upd_rule", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_recon_upd_rule" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objReconUpdateRule), "pr_recon_upd_rule", headerval.user_code, constring);
				return result;
			}
		}

	}
}

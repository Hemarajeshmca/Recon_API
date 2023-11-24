using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.ProcessModel;
using static ReconModels.ReconModel;

namespace ReconDataLayer
{
    public class ProcessData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        DBManager dbManager = new DBManager("ConnectionString");
        List<IDbDataParameter>? parameters;

        public DataTable automatchpreviewData(automatchpreviewmodel objautomatchpreview, UserManagementModel.headerValue headerval)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_code", objautomatchpreview.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ko_post_flag", objautomatchpreview.in_ko_post_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_period_from", objautomatchpreview.in_period_from, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_period_to", objautomatchpreview.in_period_to, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_automatch_flag", objautomatchpreview.in_automatch_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objautomatchpreview.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objautomatchpreview.in_user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_run_match", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //pr_run_reconrule

        public DataTable runreconruleData(runreconrule objrunreconrule, UserManagementModel.headerValue headerval)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_code", objrunreconrule.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_period_from", objrunreconrule.in_period_from, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_period_to", objrunreconrule.in_period_to, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_automatch_flag", objrunreconrule.in_automatch_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objrunreconrule.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objrunreconrule.in_user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_run_reconrule", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable undokojobData(undokojobmodel objundokojobmodel, UserManagementModel.headerValue headerval)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_job_gid", objundokojobmodel.in_job_gid, DbType.Int64));
                parameters.Add(dbManager.CreateParameter("in_undo_job_reason", objundokojobmodel.in_undo_job_reason, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objundokojobmodel.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objundokojobmodel.in_user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_set_undokojob", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable objundokoData(undokomodel objundokomodel, UserManagementModel.headerValue headerval)
        {
            try
            {
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_ko_gid", objundokomodel.in_ko_gid, DbType.Int64));
                parameters.Add(dbManager.CreateParameter("in_undo_ko_reason", objundokomodel.in_undo_ko_reason, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objundokomodel.in_user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_set_undoko", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

		//getPipelinelistData

		public DataTable getPipelinelistData(pipelinelist objpipeline, UserManagementModel.headerValue headerval)
		{
			try
			{
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_target_dataset_code", objpipeline.in_target_dataset_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				//parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_pipelinelist", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

	}
}

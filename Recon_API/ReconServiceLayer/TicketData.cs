using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.QcdmasterModel;
using ReconModels;
using static ReconModels.UserManagementModel;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace ReconDataLayer
{
    public class TicketData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter> parameters;

        public DataTable Ticketuser(ticketassign tktmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_context_code", tktmodel.in_context_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", headerval.ip_address, DbType.String));
                ds = dbManager.execStoredProcedure("pr_tkt_fetch_users_list", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_tkt_fetch_users_list" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(tktmodel), "pr_tkt_fetch_users_list", headerval.user_code, constring);
                return result;
            }
        }

        public DataTable Ticketsave_db(tktdtlmodel objmodel, headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ticket_gid_bulk", objmodel.ticket_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_no", objmodel.ticket_no, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_for", objmodel.ticket_for, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_date", objmodel.ticket_date, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_type", objmodel.ticket_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_assigned", objmodel.ticket_assigned, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_subject", objmodel.ticket_subject, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_description", objmodel.ticket_description, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_priority", objmodel.ticket_priority, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_status", objmodel.ticket_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_entity", objmodel.entity, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_department", objmodel.department, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_unit", objmodel.unit, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_screen_code", objmodel.in_screen_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_screen_name", objmodel.in_screen_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_name", objmodel.in_recon_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_code", objmodel.in_report_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_name", objmodel.in_report_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_isattachment", objmodel.ticket_isattachment, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user", objmodel.in_user, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objmodel.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_ticket_gid", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_ticket_no", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_queue_gid", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_tkt_mst_tticket", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_tkt_mst_tticket" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objmodel), "pr_tkt_mst_tticket", hv.user_code, constring);
                throw ex;
            }
        }

        public DataTable Ticketlists(Ticketlistmodel objmodel, headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", objmodel.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", objmodel.in_role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", objmodel.in_lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objmodel.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_screen_access", objmodel.in_screen_access, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_tkt_fetch_ticketlist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_tkt_fetch_ticketlist" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objmodel), "pr_tkt_fetch_ticketlist", hv.user_code, constring);
                throw ex;
            }
        }

        public DataTable AttachSave(tktattachmentmodel objmodel, headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_action", objmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_attachment_gid", objmodel.attachment_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_ticket_gid", objmodel.ticket_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_queue_gid", objmodel.queue_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_file_name", objmodel.file_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user", objmodel.in_user, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objmodel.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_attachment_gid", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_tkt_mst_tattachment", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_tkt_mst_tattachment" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objmodel), "pr_tkt_mst_tattachment", hv.user_code, constring);
                throw ex;
            }
        }

        public DataTable Threadlists(Threadlistmodel objmodel, headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", objmodel.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_gid", objmodel.in_ticket_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_no", objmodel.in_ticket_no, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", objmodel.in_lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objmodel.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_tkt_fetch_users_queue", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_tkt_fetch_users_queue" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objmodel), "pr_tkt_fetch_users_queue", hv.user_code, constring);
                throw ex;
            }
        }

        public DataTable Attachlists(ViewAttachModel objmodel, headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_action", objmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_gid", objmodel.in_ticket_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_queue_gid", objmodel.in_queue_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_attachment_gid", objmodel.in_attachment_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_file_name", objmodel.in_file_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user", objmodel.in_user, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objmodel.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_tkt_fetch_attachment_list", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_tkt_fetch_attachment_list" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objmodel), "pr_tkt_fetch_attachment_list", hv.user_code, constring);
                throw ex;
            }
        }

        public DataTable Tktsavebulk(tktdtlmodel objmodel, headerValue hv, string constring)
        {
            DataTable finalResult = new DataTable();

            try
            {

                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ticket_gid_bulk", objmodel.ticket_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_no", objmodel.ticket_no, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_for", objmodel.ticket_for, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_date", objmodel.ticket_date, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_type", objmodel.ticket_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_assigned", objmodel.ticket_assigned, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_subject", objmodel.ticket_subject, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_description", objmodel.ticket_description, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_priority", objmodel.ticket_priority, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_status", objmodel.ticket_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_entity", objmodel.entity, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_department", objmodel.department, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_unit", objmodel.unit, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_screen_code", objmodel.in_screen_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_screen_name", objmodel.in_screen_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_name", objmodel.in_recon_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_code", objmodel.in_report_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_report_name", objmodel.in_report_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ticket_isattachment", objmodel.ticket_isattachment, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user", objmodel.in_user, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objmodel.in_ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_ticket_gid", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_ticket_no", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_queue_gid", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_tkt_mst_tticket", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_tkt_mst_tticket Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + " Param:" + JsonConvert.SerializeObject(objmodel), "pr_tkt_mst_tticket", hv.user_code, constring);
                throw;
            }
        }


    }
}

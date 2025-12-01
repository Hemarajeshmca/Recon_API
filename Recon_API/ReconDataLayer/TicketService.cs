using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.QcdmasterModel;

namespace ReconServiceLayer
{
	public class TicketService
	{
        public static DataTable TicketUserAssign(ticketassign tktmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                TicketData objqcd = new TicketData();
                ds = objqcd.Ticketuser(tktmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable Ticketsave_srv(tktdtlmodel objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
               TicketData objproduct = new TicketData();
                ds = objproduct.Ticketsave_db(objmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable Ticketlist(Ticketlistmodel objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                TicketData objproduct = new TicketData();
                ds = objproduct.Ticketlists(objmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable AttachmentSave(tktattachmentmodel objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                TicketData objproduct = new TicketData();
                ds = objproduct.AttachSave(objmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable Threadllist(Threadlistmodel objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                TicketData objproduct = new TicketData();
                ds = objproduct.Threadlists(objmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable Attachlist(ViewAttachModel objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                TicketData objproduct = new TicketData();
                ds = objproduct.Attachlists(objmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable Ticketsavebulk(tktdtlmodel objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                TicketData objproduct = new TicketData();
                ds = objproduct.Tktsavebulk(objmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

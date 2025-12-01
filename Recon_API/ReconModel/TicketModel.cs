using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    public class TicketModel
    {
        public string in_user_code { get; set; }

    }

    public class ticketassign
    {
        public string? in_lang_code { get; set; }
        public string? in_ip_addr { get; set; }

        public string? in_context_code { get; set; }
    }

    public class Ticketlistmodel
    {
        public string? in_user_code { get; set; }
        public string? in_role_code { get; set; }
        public string? in_lang_code { get; set; }
        public string? in_ip_addr { get; set; }
        public string? in_action { get; set; }
        public string? in_screen_access { get; set; }
    }
    public class tktattachmentmodel
    {
        public string? in_action { get; set; }
        public int? attachment_gid { get; set; }
        public int? ticket_gid { get; set; }
        public int? queue_gid { get; set; }
        public string? file_name { get; set; }
        public string? in_user { get; set; }
        public string? in_ip_addr { get; set; }
    }
    public class tktdtlmodel
    {
        public string? ticket_gid { get; set; }
        public string? ticket_no { get; set; }
        public string? ticket_for { get; set; }
        public string? ticket_date { get; set; }
        public string? ticket_type { get; set; }
        public string? ticket_subject { get; set; }
        public string? ticket_description { get; set; }
        public string? ticket_assigned { get; set; }
        public string? ticket_priority { get; set; }
        public string? ticket_status { get; set; }
        public string? entity { get; set; }
        public string? department { get; set; }
        public string? unit { get; set; }
        public string? ticket_isattachment { get; set; }
        public string? in_user { get; set; }
        public string? in_ip_addr { get; set; }
        public string? in_action { get; set; }
        public string? in_screen_code { get; set; }
        public string? in_screen_name { get; set; }
        public string? in_recon_code { get; set; }
        public string? in_recon_name { get; set; }
        public string? in_report_code { get; set; }
        public string? in_report_name { get; set; }
    }

    public class Threadlistmodel
    {
        public string? in_user_code { get; set; }
        public int? in_ticket_gid { get; set; }
        public string? in_ticket_no { get; set; }
        public string? in_lang_code { get; set; }
        public string? in_ip_addr { get; set; }
        public string? in_action { get; set; }
    }

    public class ViewAttachModel
    {
        public string? in_user { get; set; }
        public int? in_ticket_gid { get; set; }
        public string? in_lang_code { get; set; }
        public string? in_ip_addr { get; set; }
        public string? in_action { get; set; }
        public int? in_queue_gid { get; set; }
        public int? in_attachment_gid { get; set; }
        public string? in_file_name { get; set; }
    }

    public class tktbulkassignmodel
    {
        public string? ticket_gid { get; set; }
        public string? ticket_assigned { get; set; }
        public string? in_user { get; set; }
        public string? in_ip_addr { get; set; }
        public string? in_action { get; set; }
    }

}

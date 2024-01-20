using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    internal class KnockOff_Model
    {
    }


    

    public class ReconMstTacc
    {
        public Int16  ? in_acc_gid { get; set; }
        public String in_acc_code { get; set; }
        public String in_acc_name { get; set; }
        public String in_acc_category { get; set; }
        public String in_acc_responsibility { get; set; }

        public String in_active_status { get; set; }
        public String in_action  { get; set; }
        public String in_action_by { get; set; }
        public String ? out_msg { get; set; }
        public Int16 ? out_result { get; set; }
    }

    public class RunReport
    {
        public String in_report_code { get; set; }
        public Int16 in_recon_gid { get; set; }
        public String in_condition { get; set; }
        public String in_ip_addr { get; set; }
        public bool in_outputfile_flag { get; set; }
        public String in_user_code { get; set; }
        public  Int16 ? out_result { get; set; }
        public String ? out_msg { get; set; }

    }

    public class runkosumm
    {
        public String in_recon_code { get; set; }
		public DateOnly in_period_from { get; set; }
		public DateOnly in_period_to { get; set; }
		public String in_ip_addr { get; set; }
        public String in_user_code { get; set; }
	}

    public class recondatasetinfo
    {
        public string in_recon_code { get; set; }
        public string in_dataset_code { get; set;}
        public string in_automatch_flag { get; set;}

	}

    public class runreportmodel
    {
        public string in_recon_code { get; set; }
        public string in_report_code { get; set; }
        public string in_report_param { get; set; }
        public string in_report_condition { get; set; }
        public string in_ip_addr { get; set; }
        public Boolean in_outputfile_flag { get; set; }
        public string in_user_code { get; set; }
    }
    public class undoKOmodel
	{
		public int in_ko_gid { get; set; }
		public string in_undo_ko_reason { get; set; }
		public string in_user_code { get; set; }

	}
	public class undoKOjobModel
	{
		public string in_recon_code { get; set; }
		public string in_job_type { get; set; }
		public string in_job_status { get; set; }
		public string in_from_date { get; set; }
		public string in_to_date { get; set; }
	}
	public class undomatchmodel
	{
		public string? reconcode { get; set; }
		public int job_id { get; set; }
		public string? undo_job_reason { get; set; }
		public string? in_ip_addr { get; set; }
		public string? in_user_code { get; set; }
		public string? out_msg { get; set; }
		public string? out_result { get; set; }
	}

    public class getundojobrulemodel
    {
        public string? in_recon_code { get; set; }
        public DateOnly in_start_date { get; set; }
        public DateOnly in_end_date { get; set; }
    }

    public class setundojobrulemodel
    {
        public string? in_recon_code { get; set; }
        public int in_job_gid { get; set; }
        public string? in_rule_code { get; set; }
        public string? in_undo_job_reason { get; set; }

    }
}

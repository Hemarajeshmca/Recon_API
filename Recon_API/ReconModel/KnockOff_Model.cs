﻿using System;
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

}

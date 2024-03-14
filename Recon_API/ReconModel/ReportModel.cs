using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    public class ReportModel
    {
        public class generatereportmodel
        {
            public String? in_recon_code { get; set; }
            public String? in_report_code { get; set; }
            public String? in_report_param { get; set; }
            public String? reportcondition { get; set; }
            public String? in_ip_addr { get; set; }
            public Boolean? in_outputfile_flag { get; set; }
            public String? in_user_code { get; set; }
        }

        public class reconbetweenaccmodel
        {
            public String? in_recon_code { get; set; }
            public String? in_tran_date { get; set; }
        }

        public class reconwithinaccmodel
        {
            public String? in_recon_code { get; set; }
            public String? in_tran_date { get; set; }
        }

		public class reportparamlistmodel
		{
    		public String? in_report_code { get; set; }
			public String? in_recon_code { get; set; }
		}

        public class reportTemplateModel
        {
            public int? in_reporttemplate_gid { get; set;}
			public String? in_reporttemplate_code { get; set; }
			public String? in_reporttemplate_name { get; set; }
			public String? in_report_code { get; set; }
			public String? in_action { get; set; }
			public String? in_active_status { get; set; }

		}

        public class fetchReportTemplateModel
		{
			public String? in_reporttemplate_code { get; set; }

		}

        public class reporttemplatefilterModel
        {
            public Int32? in_reporttemplatefilter_gid { get; set; }
            public String? in_reporttemplate_code { get; set; }
            public Int32? in_filter_seqno { get; set; }
            public string? in_report_field { get; set; }
            public string? in_filter_criteria { get; set; }
            public string? in_filter_value { get; set; }
            public string? in_open_parentheses_flag { get; set; }
            public string? in_close_parentheses_flag { get; set; }
            public string? in_join_condition { get; set; }
            public string? in_action { get; set; }
            public String? in_active_status { get; set; }
        }

        public class runPageReportModel
        {
            public string? in_report_code { get; set; }
            public string? in_recon_code { get; set; }
            public string in_report_condition { get; set; }
        }

        public class getPageNoReportModel
        {
            public string? in_recon_code { get; set; }
            public int? in_rptsession_gid { get; set; } 
            public int in_page_no { get; set; }
            public int in_page_size { get; set; }
            public int in_tot_records { get; set; }

        }

    }
}

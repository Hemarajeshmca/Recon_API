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
            public String? in_report_condition { get; set; }
            public String? in_ip_addr { get; set; }
            public Boolean? in_outputfile_flag { get; set; }
            public String? in_user_code { get; set; }
        }

        public class reconbetweenaccmodel
        {
            public String? in_recon_code { get; set; }
            public DateOnly? in_tran_date { get; set; }
        }

        public class reconwithinaccmodel
        {
            public String? in_recon_code { get; set; }
            public DateOnly? in_tran_date { get; set; }
        }
    }
}

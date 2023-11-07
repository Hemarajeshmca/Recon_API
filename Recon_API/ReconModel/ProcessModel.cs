using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    public class ProcessModel
    {
        public class automatchpreviewmodel
        {
            public String? in_recon_code { get; set; }
            public String? in_ko_post_flag { get; set; }
            public String? in_period_from { get; set; }
            public String? in_period_to { get; set; }   
            public String? in_automatch_flag { get; set; }
            public String? in_ip_addr { get; set; }
            public String? in_user_code { get; set; }

        }

        public class undokojobmodel
        {
            public Int32? in_job_gid { get; set; }
            public String? in_undo_job_reason { get; set; }
            public String? in_ip_addr { get; set; }
            public String? in_user_code { get; set; }
        }

        public class undokomodel
        {
            public Int32? in_ko_gid { get; set; }
            public String? in_undo_ko_reason { get; set; }
            public String? in_user_code { get; set; }
        }
    }
}

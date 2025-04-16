using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    public class KoSequenceModel
    {
        public class koseqmodel
        {
            public string? in_recon_code { get; set; }
            public string? in_seq_code { get; set; }
            public string? in_user_code { get; set; }
        }

        public class koseqsavemodel
        {
            public Int32? in_Koseq_gid { get; set; }
            public String in_recon_code { get; set; }
            public String in_recon_version { get; set; }
            public decimal in_koseq_no { get; set; }
            public String? in_koseq_type { get; set; }
            public String in_koseq_ref_code { get; set; }           
            public String in_hold_flag { get; set; }
            public String in_action { get; set; }
            public String in_active_status { get; set; }
            public String? in_action_by { get; set; }
            public String? out_msg { get; set; }
            public Int32? out_result { get; set; }
        }
        public class koseqlistmodel
        {
            public string? in_recon_code { get; set; }
            public string? in_user_code { get; set; }
        }
    }
}

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
            public String in_Koseq_recon { get; set; }
            public String in_action { get; set; }
            public String? in_action_by { get; set; }
            public String? out_msg { get; set; }
            public Int32? out_result { get; set; }
        }
        public class koseqlistmodel
        {
            public string? in_recon_code { get; set; }
            public string? in_user_code { get; set; }
        }
        public class Reconkoseqmodellist
        {
            public string? in_recon_code { get; set; }
        }
        public class seqlistmodel
        {
            public string? in_user_code { get; set; }
        }
        public class Reconversiontreemodel
        {
            public string in_recon_code { get; set; }
            public string? in_user_code { get; set; }
            public string? in_process_code { get; set; }
        }
        public class rowqcdlist
        {
            public string? in_recon_code { get; set; }
            public Int64? in_tran_gid { get; set; }
            public Int64? in_tranbrkp_gid { get; set; }
        }
        public class reconfieldqcdlist
        {
            public string? in_recon_code { get; set; }
            public string? in_depend_code { get; set; }
            public Int64? in_tran_gid { get; set; }
            public Int64? in_tranbrkp_gid { get; set; }
            public string? in_recon_field_name { get; set; }
        }
        
        public class reconexpsavemodel
        {
            public string? in_recon_code { get; set; }
            public Int64? in_tran_gid { get; set; }
            public Int64? in_tranbrkp_gid { get; set; }
            public string? in_curr_value { get; set; }
            public string? in_new_value { get; set; }
            public string? in_user_code { get; set; }
        }
    }
}

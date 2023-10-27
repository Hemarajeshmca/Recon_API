using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
    public class ReconModel
    {
        public class Recontype
        {
  
        }

        public class Reconlist
        {
            public string? in_user_code { get; set; }
           
        }

        public class fetchRecon
        {
            public string? in_recon_code { get; set; }

        }

        public class datamapping
        {
            public Int16? in_reconfield_gid { get; set; }
            public string? in_recon_code { get; set; }
            public string? in_recon_field_name { get; set; }
            public Decimal? in_display_order { get; set; }
            public string? in_dataset_code { get; set; }
            public string? in_dataset_field_name { get; set; }
            public string? in_active_status { get; set; }
            public string? in_action { get; set; }
            public string? in_user_code { get; set; }

        }

        public class Recon
        {
            public Int16? in_recon_gid { get; set; }
            public String in_recon_code { get; set; }
            public String in_recon_name { get; set; }
            public String in_recontype_code { get; set; }
            public String in_recon_automatch_partial { get; set; }
            public DateOnly in_period_from { get; set; }
            public DateOnly in_period_to { get; set; }
            public String in_until_active_flag { get; set; }
            public String in_active_status { get; set; }
            public String in_action { get; set; }
            public String in_action_by { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }

        public class Recondataset
        {
            public Int16? in_recondataset_gid { get; set; }
            public String? in_recon_code { get; set; }
            public String? in_dataset_code { get; set; }
            public String? in_dataset_type { get; set; }
            public String? in_parent_dataset_code { get; set; }
            public String? in_active_status { get; set; }
            public String? in_action { get; set; }
            public String? in_user_code { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }

        public class getReconDataMappingList
        {
            public String? in_recon_code { get; set; }
            public String? in_recon_field_name { get; set; }
			public String? in_dataset_code { get; set; }
		}

        public class getCondition
        {
            public String? in_condition_type { get; set; }
            public String? in_field_type { get; set;}

		}

        public class getdataagainsRecon
        {
            public String? in_recon_code { get; set; }
        }

        public class getFieldAgainstReconList
        {
            public String? in_recon_code { get; set; }
		}

	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
	public class UpdateReconModel
	{
		public class ReconUpdateRuleModel
		{
			public string in_base_recon_code { get; set; }
			public string in_base_rule_code { get; set; }
			public string in_update_recon_code { get; set; }
			public string in_update_rule_code { get; set; }
			public string in_user_code { get; set; }
		}

		public class ReconUpdatePreprocessModel
		{
			public string in_base_recon_code { get; set; }
			public string in_base_preprocess_code { get; set; }
			public string in_update_recon_code { get; set; }
			public string in_update_preprocess_code { get; set; }
			public string in_user_code { get; set; }
		}

		public class ReconUpdateThemeModel
		{
			public string in_base_recon_code { get; set; }
			public string in_base_theme_code { get; set; }
			public string in_update_recon_code { get; set; }
			public string in_update_theme_code { get; set; }
			public string in_user_code { get; set; }
		}

		public class ReconagainstRuleModel
		{
			public string in_rule_name { get; set; }
		}

		public class ReconagainstPreProcessModel
		{
			public string in_preprocess_name { get; set; }
		}

		public class ReconagainstThemeModel
		{
			public string in_theme_name { get; set; }
		}

        public class datasetmapModel
        {
            public int? in_datasetmap_gid { get; set; }
            public string? in_recon_code { get; set; }
            public string? in_active_status { get; set; }
            public string? in_action { get; set; }
            public string? in_action_by { get; set; }
            public string? in_user_code { get; set; }

        }

		public class datasetlistmappedModel
		{
			public string? in_recon_code { get; set; }
			public string? in_target_recon_code { get; set; }

		}
        public class Reconalllistmodel
        {
            public string? in_user_code { get; set; }
        }


    }

}

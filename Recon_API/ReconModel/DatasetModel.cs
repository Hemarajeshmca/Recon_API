﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
	public class DatasetModel
	{
		public class Datasetlistmodel
		{
			public string? dataset_name { get; set; }
			public string? datasetCode { get; set; }
			public int dataset_id { get; set; }
			public string? dataset_category { get; set; }
			public string? active_status { get; set; }
			public string? active_status_desc { get; set; }
			public int in_user_gid { get; set; }
			public string? in_user_code { get; set; }
			public string? in_active_status { get; set; }
		}
		public class DatasetHeadermodel
		{
			public string? dataset_name { get; set; }
			public string? datasetCode { get; set; }
			public Int32 dataset_id { get; set; }
			public string? dataset_category { get; set; }
            public string? clone_dataset { get; set; }
            public string? active_status { get; set; }
			public string? inactive_reason { get; set; }
			public string? in_action { get; set; }
			public string? in_action_by { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
		public class Datasetdetailmodel
		{
			public string? datasetCode { get; set; }
			public int datasetdetail_id { get; set; }
			public string? field_name { get; set; }
			public string? field_type { get; set; }
			public string? field_length { get; set; }
			public int? precision_length { get; set; }
			public int? scale_length { get; set; }
			public string? field_mandatory { get; set; }
			public string? in_action { get; set; }
			public string? in_action_by { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
		public class Datasetdetailmodellist
		{
			public Int16 datasetCode { get; set; }
		}

        public class clonedataset
        {
            public string? in_clone_dataset_code { get; set; }
            public string? in_new_dataset_code { get; set; }
            public string? in_action_by { get; set; }

        }
    }
}


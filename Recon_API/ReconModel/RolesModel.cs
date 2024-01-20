using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
	public class RolesModel
	{
		public class rolelistModel
		{
			public Int32 in_role_gid { get; set; }
			public string in_role_code { get; set; }
			public string in_role_name { get; set; }
			public string in_active_status { get; set; }
			public string in_active_reason { get; set; }
			public string in_action { get; set; }
		}

		public class roledetailsModel
		{
			public int in_role_gid { get; set; }
		}

		public class saveRoleAccessModel
		{
			public string roledetails { get; set; }

		}

		public class RolefetchModel
		{
			public string in_role_code { get; set; }
		}

		public class saveRoleAccessModellist
		{
			public int in_rolerights_gid { get; set; }
			public string in_role_code { get; set; }
			public string in_menu_code { get; set; }
			public string in_add_flag { get;set; }
			public string in_modify_flag { get; set; }
			public string in_download_flag { get; set; }
			public string in_view_flag { get; set; }
			public string in_deny_flag { get; set; }
			public string in_active_status { get; set; }
			public string in_delete_flag { get;set; }

			public string in_action_by { get; set; }
		}
	}
}

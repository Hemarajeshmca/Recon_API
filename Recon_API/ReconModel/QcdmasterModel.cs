using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconModels
{
	public class QcdmasterModel
	{
		public string in_user_code { get; set; }

	}

	public class Qcdgridread
	{
		public string in_user_code { get; set; }
		public string in_master_code { get; set; }
	}

	public class mainQCDMaster
	{
		public string action { get; set; }
		public string active_status { get; set; }
		public string masterCode { get; set; }
		public int masterGid { get; set; }
		public string mastermutiplename { get; set; }
		public string masterName { get; set; }
		public string masterShortCode { get; set; }
		public string masterSyscode { get; set; }
		public string ParentMasterSyscode { get; set; }
		public string depend_parent_master_syscode { get; set; }
		public string depend_master_syscode { get; set; }
		public string depend_flag { get; set; }
	}
    public class getmanualthememodel
    {
        public string? recon_code { get; set; }      
        public string? in_user_code { get; set; }
    }
    public class manualthememodel
    {
        public string? recon_code { get; set; }
        public string? manualtheme_desc { get; set; }
        public Int32 manualtheme_id { get; set; }
        public string? active_status { get; set; }
        public string? in_action { get; set; }
        public string? in_user_code { get; set; }
    }
    public class referencemodel
    {
        public string? recon_code { get; set; }
        public string? ref_code { get; set; }
        public string? ref_name { get; set; }
        public string? ref_value { get; set; }
        public string? active_status { get; set; }
        public Int32 ref_gid { get; set; }
        public string? in_action { get; set; }
        public string? in_user_code { get; set; }
    }
    public class getreferencemodel
    {
        public string? recon_code { get; set; }
        public string? in_user_code { get; set; }
    }

    public class Qcdticket
    {
        public string? in_user_code { get; set; }
        public string? in_master_code { get; set; }
        public string? in_role_code { get; set; }
        public string? in_lang_code { get; set; }
    }
}

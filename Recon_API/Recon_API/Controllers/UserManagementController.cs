using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using static ReconModels.UserManagementModel;
using static ReconServiceLayer.UserManagementService;
using System.Data;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        [HttpPost("Loginvalidation")]
        public DataTable Loginvalidation(Login_model objmodel)
        {
            DataTable response = new DataTable();
            try
            {
                
                string controls = "Login";
                //LogHelper.WriteLog("UserId" + objmodel.user_id, controls);
                //LogHelper.WriteLog("UserName" + objmodel.user_name, controls);
                response = login_serivce.Loginvalidation(objmodel);
            }
            catch (Exception e)
            {
            }
            return response;
        }

    }
}

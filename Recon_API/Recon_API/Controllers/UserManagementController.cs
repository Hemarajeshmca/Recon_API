using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using static ReconModels.UserManagementModel;
using static ReconServiceLayer.UserManagementService;
using System.Data;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Linq;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserManagementController : ControllerBase
	{
		private IConfiguration _configuration;
		public UserManagementController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";
		[HttpPost("Loginvalidation")]
		public IActionResult Loginvalidation(Login_model objmodel)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			DataTable response = new DataTable();
			try
			{
				response = login_serivce.Loginvalidation(objmodel, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

        [HttpPost("changepass_save")]
        public IActionResult changepass_save(change_password objmodel)
        {
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
            DataTable response = new DataTable();
            try
            {
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("langcode", out var langcode) ? langcode.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("roleCode", out var roleCode) ? roleCode.First() : "";
                objmodel.user_id = getvalue;
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
                response = login_serivce.changepass_save(objmodel, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


        [HttpPost("dashboard")]
        public IActionResult dashboard(dashboardmodel objdashboard)
        {
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
            DataSet response = new DataSet();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("langcode", out var langcode) ? langcode.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("roleCode", out var roleCode) ? roleCode.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = login_serivce.dashboardService(objdashboard, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

    }
 
}

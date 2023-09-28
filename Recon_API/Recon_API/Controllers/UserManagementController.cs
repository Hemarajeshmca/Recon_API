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
		[HttpPost("Loginvalidation")]
		public IActionResult Loginvalidation(Login_model objmodel)
		{
			DataTable response = new DataTable();
			try
			{
				response = login_serivce.Loginvalidation(objmodel);
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
			headerValue header_value = new headerValue();
            DataTable response = new DataTable();
            try
            {
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("langcode", out var langcode) ? langcode.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("roleCode", out var roleCode) ? roleCode.First() : "";
                objmodel.user_id = getvalue;
				header_value.userCode = getvalue;
				header_value.langCode = getlangCode;
				header_value.roleCode = getRoleCode;
                response = login_serivce.changepass_save(objmodel, header_value);
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

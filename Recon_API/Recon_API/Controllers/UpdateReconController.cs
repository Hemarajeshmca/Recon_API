using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using System.Data;
using static ReconModels.ReconModel;
using static ReconModels.UserManagementModel;
using static ReconModels.UpdateReconModel;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UpdateReconController : ControllerBase
	{
		private IConfiguration _configuration;
		public UpdateReconController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";

		[HttpPost("ReconUpdateRule")]
		public IActionResult ReconUpdateRule(ReconUpdateRuleModel objReconUpdateRule)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = UpdateReconService.ReconUpdateRuleService(objReconUpdateRule, header_value, constring);
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

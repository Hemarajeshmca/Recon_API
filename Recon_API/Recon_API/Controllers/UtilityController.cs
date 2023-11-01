using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.UserManagementModel;
using System.Data;
using static ReconModels.UtilityModel;
using static ReconServiceLayer.UtilityService;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UtilityController : ControllerBase
	{
		[HttpPost("jobStatus")]
		public IActionResult JobStatus(JobStatusList objobstatus)
		{
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("in_user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("in_lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("in_role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = UtilityService.getJobStatusList(objobstatus, header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpGet("jobtype")]
		public IActionResult Jobtype()
		{
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("in_user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("in_lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("in_role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = UtilityService.getJobtypeList(header_value);
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

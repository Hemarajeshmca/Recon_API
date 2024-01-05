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
		private IConfiguration _configuration;
		public UtilityController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";
		UtilityService _fileService = new UtilityService();

		[HttpPost("jobStatus")]
		public IActionResult JobStatus(JobStatusList objobstatus)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
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
				response = UtilityService.getJobStatusList(objobstatus, header_value, constring);
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
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
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
				response = UtilityService.getJobtypeList(header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}


		[HttpPost("jobcompleted")]
		public IActionResult jobcompleted(JobCompleted objJobCompleted)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
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
				response = UtilityService.objJobCompletedservice(objJobCompleted, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}


		[HttpPost("jobinpogress")]
		public IActionResult jobinpogress(JobCompleted objJobCompleted)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
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
				response = UtilityService.jobinpogressservice(objJobCompleted, header_value, constring);
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

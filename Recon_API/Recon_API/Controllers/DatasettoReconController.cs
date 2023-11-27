using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.DatasetModel;
using static ReconModels.UserManagementModel;
using System.Data;
using ReconModels;
using static ReconModels.DatasettoReconmodel;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DatasettoReconController : ControllerBase
	{
		[HttpPost("DatasettoReconRead")]
		public IActionResult DatasettoReconRead(DatasettoReconmodellist DatasettoReconmodellist)
		{
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
				response = DatasettoReconservice.DatasettoReconRead(DatasettoReconmodellist, header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[HttpPost("DatasettoReconprocess")]
		public IActionResult DatasettoReconprocess(DatasettoReconmodelprocess DatasettoReconmodelprocess)
		{
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
				response = DatasettoReconservice.DatasettoReconprocess(DatasettoReconmodelprocess, header_value);
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.CommonModel;
using static ReconModels.UserManagementModel;
using System.Data;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommonController : ControllerBase
	{
		private IConfiguration _configuration;
		public CommonController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";
		[HttpPost("errorLog")]
		public void errorLog(errorlogModel objerrorlog)
		{
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = CommonService.Commonservice(objerrorlog, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				//return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				//return Problem(title: e.Message);
			}
		}

        [HttpPost("configvalue")]
        public IActionResult configvalue(configvalueModel objconfigvalue)
        {
            headerValue header_value = new headerValue();
            DataTable response = new DataTable();
            try
            {
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.configvalueservice(objconfigvalue, header_value, constring);
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

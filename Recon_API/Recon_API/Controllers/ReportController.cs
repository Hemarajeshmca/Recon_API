using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.UserManagementModel;
using System.Data;
using static ReconModels.ReportModel;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpPost("generatereport")]
        public IActionResult generatereport(generatereportmodel objgeneratereportmodel)
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
                response = ReportService.generatereportservice(objgeneratereportmodel, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


        [HttpPost("reconbetweenacc")]
        public IActionResult reconbetweenacc(reconbetweenaccmodel objreconbetweenaccmodel)
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
                response = ReportService.reconbetweenaccservice(objreconbetweenaccmodel, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("reconwithinacc")]
        public IActionResult reconwithinacc(reconwithinaccmodel objreconwithinaccmodel)
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
                response = ReportService.reconwithinaccservice(objreconwithinaccmodel, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


		[HttpPost("getreportlist")]
		public IActionResult getreportlist()
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
				response = ReportService.getreportlistservice(header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("getreportparamlist")]
		public IActionResult getreportparamlist(reportparamlistmodel objreportparamlistmodel)
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
				response = ReportService.getreportparamlistservice(objreportparamlistmodel, header_value);
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

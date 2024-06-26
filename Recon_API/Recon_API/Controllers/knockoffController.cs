using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconModels;
using ReconServiceLayer;
using SharpYaml.Serialization;
using System.Collections.Generic;
using System.Data;
using static ReconModels.UserManagementModel;
using System.Net;
using Org.BouncyCastle.Utilities.Net;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class knockoffController : ControllerBase
    {
		private IConfiguration _configuration;
		public knockoffController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";
		log4net.ILog logger = log4net.LogManager.GetLogger(typeof(knockoffController));

        knockoffService knockOffService = new knockoffService();

       
        Dictionary<string, object> returnObj= new Dictionary<string, object>();

        [HttpPost("ReconMstTAcc")]
        public IActionResult ReconMstTAcc([FromBody] ReconMstTacc reconMstTacc)
        {
            try
            {
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				DataSet ds = knockOffService.ReconMstTAcc(reconMstTacc, constring);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                return Problem(
                    title: ex.Message
                    );
            }
            // return Ok(returnObj);
            
        }

        [HttpPost("runReport")]
        public IActionResult runReport([FromBody] RunReport runReport)
        {
            try
            {
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				DataSet ds=  knockOffService.runReport(runReport, constring);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                 return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                return Problem(
                    title: ex.Message
                    );
            }
           
        }


		[HttpPost("runkosumm")]
		public IActionResult runkosumm([FromBody] runkosumm objrunkosumm)
		{
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				DataSet ds = knockOffService.runkosummService(objrunkosumm, constring);
				var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
				return Ok(serializedProduct);
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return Problem( title: ex.Message);
			}

		}

		[HttpPost("recondatasetinfo")]
		public IActionResult recondatasetinfo([FromBody] recondatasetinfo objrecondatasetinfo)
		{
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				DataSet ds = knockOffService.recondatasetinfoService(objrecondatasetinfo, constring);
				var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
				return Ok(serializedProduct);
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return Problem(title: ex.Message);
			}

		}

        [HttpPost("undorunreport")]
		public IActionResult undorunreport([FromBody] runreportmodel objrunreport)
		{
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				DataTable dt = knockOffService.undorunreportService(objrunreport, constring);
				var serializedProduct = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
				return Ok(serializedProduct);
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return Problem(title: ex.Message);
			}

		}

		[HttpPost("undoKO")]
		public IActionResult undoKO([FromBody] undoKOmodel objundoKO)
		{
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				DataTable dt = knockOffService.undoKOService(objundoKO, constring);
				var serializedProduct = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
				return Ok(serializedProduct);
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return Problem(title: ex.Message);
			}

		}
		[HttpPost("undoKOjob")]
		public IActionResult undoKOjob([FromBody] undoKOjobModel objundoKO)
		{
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				DataTable dt = knockOffService.undoKOjobService(objundoKO, constring);
				var serializedProduct = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
				return Ok(serializedProduct);
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return Problem(title: ex.Message);
			}
		}
		[HttpPost("undomatchjob")]
		public IActionResult undomatchjob([FromBody] undomatchmodel objundoKO)
		{
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				DataTable dt = knockOffService.undomatchjobService(objundoKO, constring);
				var serializedProduct = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
				return Ok(serializedProduct);
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return Problem(title: ex.Message);
			}

		}

		[HttpPost("getundojobrule")]
		public IActionResult getundojobrule(getundojobrulemodel objgetundojobrule)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			DataSet response = new DataSet();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = knockOffService.getundojobruleService(objgetundojobrule, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}


        [HttpPost("setundojobrule")]
        public IActionResult setundojobrule(setundojobrulemodel objsetundojobrule)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            headerValue header_value = new headerValue();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				var ip_Address = Request.Headers.TryGetValue("ipaddress", out var ipaddress) ? ipaddress.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
				header_value.ip_address = ip_Address;
                response = knockOffService.setundojobruleService(objsetundojobrule, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }



		[HttpPost("getruleagainstjob")]
		public IActionResult getruleagainstjob(getruleagainstjobmodel objgetruleagainstjob)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				var ip_Address = Request.Headers.TryGetValue("ipaddress", out var ipaddress) ? ipaddress.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				header_value.ip_address = ip_Address;
				response = knockOffService.getruleagainstjobService(objgetruleagainstjob, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}



		[HttpPost("getthemeagainstRecon")]
		public IActionResult getthemeagainstRecon(getthemeagainstReconmodel objgetthemeagainstRecon)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				var ip_Address = Request.Headers.TryGetValue("ipaddress", out var ipaddress) ? ipaddress.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				header_value.ip_address = ip_Address;
				response = knockOffService.getthemeagainstReconService(objgetthemeagainstRecon, header_value, constring);
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


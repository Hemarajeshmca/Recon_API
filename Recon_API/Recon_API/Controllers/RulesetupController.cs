using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.RulesetupModel;
using System.Data;
using static ReconModels.UserManagementModel;
using static ReconModels.ReconModel;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesetupController : ControllerBase
    {
		private IConfiguration _configuration;
		public RulesetupController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";
		[HttpPost("rulelist")]
        public IActionResult Rulelist(Rulesetuplist objrulesetuplist)
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
				response = RulesetupService.getRulelist(objrulesetuplist, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("ruleheader")]
        public IActionResult Ruleheader(Rulesetupheader objrulesetupheader)
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
				response = RulesetupService.ruleheader(objrulesetupheader, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("rulegrouping")]
        public IActionResult Rulegrouping(Rulegrouping objrulegrouping)
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
				response = RulesetupService.Rulegrouping(objrulegrouping, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("ruleidentifier")]
        public IActionResult RuleIdentifier(RuleIdentifier objruleidentifier)
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
				response = RulesetupService.Ruleidentifier(objruleidentifier, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("rulecondition")]
        public IActionResult RuleCondition(RuleCondition objrulecondition)
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
				response = RulesetupService.Rulecondition(objrulecondition, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("fetchrule")]
        public IActionResult fetchrule(fetchRule objfetchrule)
        {
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			DataSet response = new DataSet();
            try
            {
				var getvalue = Request.Headers.TryGetValue("in_user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("in_lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("in_role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = RulesetupService.Rulefetch(objfetchrule, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

		[HttpPost("getCondition")]
		public IActionResult getCondition(getCondition objcondition)
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
				response = RulesetupService.getCondition(objcondition, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("getdataagainsRecon")]
		public IActionResult getdataagainsRecon(getdataagainsRecon objdatarecon)
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
				response = RulesetupService.getdataagainsRecon(objdatarecon, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("getRecon")]
		public IActionResult getRecon(getdataagainsRecon objdatarecon)
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
				response = RulesetupService.getRecon(objdatarecon, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("getruleagainstRecon")]
		public IActionResult getruleagainstRecon(getruleagainstRecon objRecon)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
            DataSet ds = new DataSet();

            try
            {
				var getvalue = Request.Headers.TryGetValue("in_user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("in_lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("in_role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
                //ds = ReconService.fetchReconDetails(objfetch, header_value);
                //var serializedProduct = JsonConvert.SerializeObject(ds, Formatting.None);
                //return Ok(serializedProduct);
                ds = RulesetupService.getruleagainstRecon(objRecon, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(ds, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("rulefieldorder")]
		public IActionResult rulefieldorder(Rulefieldorder objRulefieldorder)
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
				response = RulesetupService.rulefieldorder(objRulefieldorder, header_value, constring);
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

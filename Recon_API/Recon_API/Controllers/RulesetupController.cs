using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.RulesetupModel;
using System.Data;
using static ReconModels.UserManagementModel;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesetupController : ControllerBase
    {
        [HttpPost("rulelist")]
        public IActionResult Rulelist(Rulesetuplist objrulesetuplist)
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
				response = RulesetupService.getRulelist(objrulesetuplist, header_value);
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
				response = RulesetupService.ruleheader(objrulesetupheader, header_value);
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
				response = RulesetupService.Rulegrouping(objrulegrouping, header_value);
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
				response = RulesetupService.Ruleidentifier(objruleidentifier, header_value);
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
				response = RulesetupService.Rulecondition(objrulecondition, header_value);
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
				response = RulesetupService.Rulefetch(objfetchrule, header_value);
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

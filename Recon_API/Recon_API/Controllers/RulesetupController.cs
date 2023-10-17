using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.RulesetupModel;
using System.Data;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesetupController : ControllerBase
    {
        [HttpPost("rulelist")]
        public IActionResult Rulelist(Rulesetuplist objrulesetuplist)
        {
            DataTable response = new DataTable();
            try
            {
                response = RulesetupService.getRulelist(objrulesetuplist);
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
            DataTable response = new DataTable();
            try
            {
                response = RulesetupService.ruleheader(objrulesetupheader);
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
            DataTable response = new DataTable();
            try
            {
                response = RulesetupService.Rulegrouping(objrulegrouping);
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
            DataTable response = new DataTable();
            try
            {
                response = RulesetupService.Ruleidentifier(objruleidentifier);
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
            DataTable response = new DataTable();
            try
            {
                response = RulesetupService.Rulecondition(objrulecondition);
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
            DataSet response = new DataSet();
            try
            {
                response = RulesetupService.Rulefetch(objfetchrule);
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

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconModels;
using ReconServiceLayer;
using ReconServiceLayer.Interface;
using System.Data;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KillJobController : Controller
    {
        private readonly IKillJobService _KillJobService;
        private IConfiguration _configuration;
        DataTable response = new DataTable();
        DataSet ds = new DataSet();
        public KillJobController(IKillJobService killJobService, IConfiguration configuration)
        {
            _KillJobService = killJobService;
            _configuration = configuration;
        }

        [HttpPost("setKilljob")]
        public IActionResult setKilljob(KilljobModel objKilljobmodel)
        {
            //constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            UserManagementModel.headerValue header_value = new UserManagementModel.headerValue();
            try
            {
                //string jsonString = JsonConvert.SerializeObject(objReportqueuemodel);
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = _KillJobService.setKillJobService(objKilljobmodel.processId, objKilljobmodel.action, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("getKilljob")]
        public IActionResult getKilljob([FromBody] KilljobModel objKilljobmodel)
        {
            UserManagementModel.headerValue header_value = new UserManagementModel.headerValue();
            try
            {
                //string jsonString = JsonConvert.SerializeObject(objReportqueuemodel);
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = _KillJobService.getKillJobService(objKilljobmodel.processId, objKilljobmodel.action, header_value);
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

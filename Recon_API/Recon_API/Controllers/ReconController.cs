using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconModels;
using ReconServiceLayer;
using System.Data;
using System.Data.Common;
using static ReconModels.ReconModel;
using static ReconModels.UserManagementModel;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReconController : ControllerBase
    {
        [HttpGet("recontype")]
        public IActionResult ReconType()
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
				response = ReconService.getReconType(header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


        [HttpPost("reconlist")]
        public IActionResult ReconList(Reconlist objreconlist)
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
				response = ReconService.getReconList(objreconlist, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


        [HttpPost("fetchrecondetails")]
        public IActionResult fetchReconDetails(fetchRecon objfetch)
        {
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
				ds = ReconService.fetchReconDetails(objfetch, header_value);
                var serializedProduct = JsonConvert.SerializeObject(ds, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("recondatamapping")]
        public IActionResult recondatamapping(datamapping objdatamapping)
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
				response = ReconService.recondatamapping(objdatamapping, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


        [HttpPost("Recon")]
        public IActionResult Recon([FromBody] Recon recon)
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
				response = ReconService.Recon(recon, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                return Problem(title: ex.Message);
            }
        }


        [HttpPost("Recondataset")]
        public IActionResult Recondataset([FromBody] Recondataset objrecondataset)
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
				response = ReconService.Recondataset(objrecondataset, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                return Problem(title: ex.Message);
            }
        }

        [HttpPost("getReconDataMappingList")]
        public IActionResult getReconDataMappingList([FromBody] getReconDataMappingList objdatamappinglist)
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
				response = ReconService.Recondatamappinglist(objdatamappinglist, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                return Problem(title: ex.Message);
            }
        }

    }
}

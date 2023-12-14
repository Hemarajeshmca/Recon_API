using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconModels;
using ReconServiceLayer;
using System.Data;
using static ReconModels.CommonModel;
using static ReconModels.DatasetModel;
using static ReconModels.UserManagementModel;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DatasetController : ControllerBase
	{
		[HttpPost("DatasetRead")]
		public IActionResult DatasetRead(Datasetlistmodel Datasetlistmodel)
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
				response = DatasetService.DatasetRead(Datasetlistmodel, header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[HttpPost("DatasetHeader")]
		public IActionResult DatasetHeader(DatasetHeadermodel Datasetheadermodel)
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
				response = DatasetService.DatasetHeader(Datasetheadermodel, header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
                CommonController errcon = new CommonController();
				errorlogModel model = new errorlogModel();
				model.in_errorlog_text = e.Message;
				model.in_ip_addr = "Localhost";
				model.in_proc_name = "DatasetHeader";
				model.in_source_name = "Method";
                errcon.errorLog(model);
                return Problem(title: e.Message);
			}
		}
		[HttpPost("DatasetDetail")]
		public IActionResult DatasetDetail(Datasetdetailmodel Datasetdetailmodel)
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
				response = DatasetService.DatasetDetail(Datasetdetailmodel, header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[HttpPost("DatasetReaddetail")]
		public IActionResult DatasetReaddetail(Datasetdetailmodellist Datasetdetailmodellist)
		{
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
				response = DatasetService.DatasetReaddetail(Datasetdetailmodellist, header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[HttpPost("getfieldtype")]
		public IActionResult getfieldtype()
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
				response = DatasetService.getfieldtype(header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

        [HttpPost("clonedataset")]
        public IActionResult clonedataset(clonedataset objclonedataset)
        {
            DataTable response = new DataTable();
            try
            {
                response = DatasetService.CloneDataset(objclonedataset);
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

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.DatasettoReconmodel;
using static ReconModels.UserManagementModel;
using System.Data;
using static ReconModels.ReconVersionmodel;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReconVersionController : ControllerBase
	{
		private IConfiguration _configuration;
        private ReconVersionSrv _reconVersionService;

        public ReconVersionController(IConfiguration configuration, ReconVersionSrv reconVersionService)
		{
			_configuration = configuration;
            _reconVersionService = reconVersionService;
        }
		string constring = "";
		[HttpPost("ReconVersionfetch")]
		public IActionResult ReconVersionfetch(ReconVersionmodellist ReconVersionmodellist)
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
				response = ReconVersionSrv.ReconVersionfetch(ReconVersionmodellist, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("ReconVersionhistory")]
		public IActionResult ReconVersionhistory(ReconVersionhsitorylist ReconVersionhsitorylist)
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
				response = ReconVersionSrv.ReconVersionhistory(ReconVersionhsitorylist, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("ReconVersionsave")]
		public IActionResult ReconVersionsave(ReconVersionmodelsave ReconVersionmodelsave)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
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
				response = ReconVersionSrv.ReconVersionsave(ReconVersionmodelsave, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

        [HttpPost("ReconReportVersionhistory")]
        public IActionResult ReconReportVersionhistory(ReconReportVersionhistoryModel objReconReportVersionhistory)
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
                byte[] pdfBytes = _reconVersionService.ReconReportVersionhistoryService(objReconReportVersionhistory, header_value, constring);
                //var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                //if (pdfBytes != null)
                //{
                //    return File(pdfBytes, "application/pdf", "Recon_Version.pdf");
                //}
                //else
                //{
                //    // Handle the case where pdfBytes is null
                //    byte[] errorBytes = System.Text.Encoding.UTF8.GetBytes("Error generating PDF");
                //    return File(errorBytes, "application/pdf", "Error.pdf");
                //}
                return File(pdfBytes, "application/pdf", "Recon_Version.pdf");
                //return pdfBytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}

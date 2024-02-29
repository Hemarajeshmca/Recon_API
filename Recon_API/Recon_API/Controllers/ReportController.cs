using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.UserManagementModel;
using System.Data;
using static ReconModels.ReportModel;
using static ReconModels.ReconModel;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
		private IConfiguration _configuration;
		public ReportController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";
		[HttpPost("generatereport")]
        public IActionResult generatereport(generatereportmodel objgeneratereportmodel)
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
                response = ReportService.generatereportservice(objgeneratereportmodel, header_value, constring);
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
                response = ReportService.reconbetweenaccservice(objreconbetweenaccmodel, header_value, constring);
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
                response = ReportService.reconwithinaccservice(objreconwithinaccmodel, header_value, constring);
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
				response = ReportService.getreportlistservice(header_value, constring);
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
				response = ReportService.getreportparamlistservice(objreportparamlistmodel, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

        [Route("ExectionReport")]
        [HttpPost]
        public IActionResult ExectionReport(Report_model user)
        {
            //DataTable response = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            string[] response = { };
            try
            {
                response = ReportService.ExectionReport(user, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }

        [Route("MonthendReport")]
        [HttpPost]
        public async Task<IActionResult> MonthendReport(MonthendReportModel objMonthendReport)
        {
            DataSet ds = new DataSet();
            headerValue header_value = new headerValue();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                ds = await ReportService.MonthendReportService(objMonthendReport, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(ds, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }


		[Route("getReportTemplateList")]
		[HttpGet]
		public IActionResult getReportTemplateList()
		{
			DataTable dt = new DataTable();
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				dt = ReportService.getReportTemplateListService(constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);

			}
		}


		[Route("reportTemplate")]
		[HttpPost]
		public IActionResult reportTemplate(reportTemplateModel objreportTemplate)
		{
			DataTable dt = new DataTable();
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				dt = ReportService.reportTemplateService(objreportTemplate, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);

			}
		}


		[Route("fetchReportTemplate")]
		[HttpPost]
		public IActionResult fetchReportTemplate(fetchReportTemplateModel objfetchReportTemplate)
		{
			DataSet ds = new DataSet();
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				ds = ReportService.fetchReportTemplateService(objfetchReportTemplate, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(ds, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}


		[Route("reporttemplatefilter")]
		[HttpPost]
		public IActionResult reporttemplatefilter(reporttemplatefilterModel objreporttemplatefilter)
		{
			DataTable dt = new DataTable();
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
			headerValue header_value = new headerValue();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				dt = ReportService.reporttemplatefilterService(objreporttemplatefilter, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);

			}
		}

        #region

        // pr_run_pagereport

        [Route("runPageReport")]
        [HttpPost]
        public IActionResult runPageReport(runPageReportModel objrunPageReport)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            headerValue header_value = new headerValue();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.runPageReportService(objrunPageReport, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }

        #endregion

        #region

        [Route("getPaginationreport")]
        [HttpPost]
        public IActionResult getPaginationreport()
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            headerValue header_value = new headerValue();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.getPaginationreportService(constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }
        #endregion

        #region

        [Route("getPageNoReport")]
        [HttpPost]
        public IActionResult getPageNoReport(getPageNoReportModel objgetPageNoReport)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            headerValue header_value = new headerValue();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.getPageNoReportService(objgetPageNoReport, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }

        #endregion
    }
}

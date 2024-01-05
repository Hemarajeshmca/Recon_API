using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconModels;
using ReconServiceLayer;
using SharpYaml.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Net;

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
	}
}


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
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(knockoffController));

        knockoffService knockOffService = new knockoffService();

       
        Dictionary<string, object> returnObj= new Dictionary<string, object>();
        

      



        [HttpPost("ReconMstTAcc")]
        public IActionResult ReconMstTAcc([FromBody] ReconMstTacc reconMstTacc)
        {
            try
            {
                DataSet ds = knockOffService.ReconMstTAcc(reconMstTacc);
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
               DataSet ds=  knockOffService.runReport(runReport);
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
				DataSet ds = knockOffService.runkosummService(objrunkosumm);
				var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
				return Ok(serializedProduct);
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return Problem( title: ex.Message);
			}

		}
	}
}


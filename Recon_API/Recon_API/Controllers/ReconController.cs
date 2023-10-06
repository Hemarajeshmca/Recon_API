using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using System.Data;
using static ReconModels.ReconModel;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReconController : ControllerBase
    {
        [HttpGet("recontype")]
        public IActionResult ReconType()
        {
            DataTable response = new DataTable();
            try
            {
                response = ReconService.getReconType();
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
            DataTable response = new DataTable();
            try
            {
                response = ReconService.getReconList(objreconlist);
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
            DataTable response = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                ds = ReconService.fetchReconDetails(objfetch);
                var serializedProduct = JsonConvert.SerializeObject(ds, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

    }
}

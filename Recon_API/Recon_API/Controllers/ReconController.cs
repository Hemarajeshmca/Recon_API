using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using System.Data;
using System.Data.Common;
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

        [HttpPost("recondatamapping")]
        public IActionResult recondatamapping(datamapping objdatamapping)
        {
            DataTable response = new DataTable();
            try
            {
                response = ReconService.recondatamapping(objdatamapping);
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
            DataTable response = new DataTable();
            try
            {
                response = ReconService.Recon(recon);
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
            DataTable response = new DataTable();
            try
            {
                response = ReconService.Recondataset(objrecondataset);
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
            DataTable response = new DataTable();
            try
            {
                response = ReconService.Recondatamappinglist(objdatamappinglist);
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

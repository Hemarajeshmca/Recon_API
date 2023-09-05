using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconModels;
using ReconServiceLayer;
using System.Data;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MastersController));

        MastersService mastersService = new MastersService();

        Dictionary<string, object> returnObj = new Dictionary<string, object>();

        [HttpPost("Reconfieldmapping")]
        public IActionResult Reconfieldmapping([FromBody] Reconfieldmapping reconfieldmapping)
        {
            try
            {
                DataSet ds = mastersService.Reconfieldmapping(reconfieldmapping);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }

        [HttpPost("Recon")]
        public IActionResult Recon([FromBody] Recon recon)
        {
            try
            {
                DataSet ds = mastersService.Recon(recon);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }

        [HttpPost("Reconacc")]
        public IActionResult Reconacc([FromBody] Reconacc reconacc)
        {
            try
            {
                DataSet ds = mastersService.Reconacc(reconacc);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }

        [HttpPost("Reconfield")]
        public IActionResult Reconfield([FromBody] Reconfield reconfield)
        {
            try
            {
                DataSet ds = mastersService.Reconfield(reconfield);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }

        [HttpPost("Acc")]
        public IActionResult Acc([FromBody] Acc acc)
        {
            try
            {
                DataSet ds = mastersService.Acc(acc);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }

        [HttpPost("Reconfiletemplate")]
        public IActionResult Reconfiletemplate([FromBody] Reconfiletemplate reconfiletemplate)
        {
            try
            {
                DataSet ds = mastersService.Reconfiletemplate(reconfiletemplate);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Mstrule")]
        public IActionResult Mstrule([FromBody] Mstrule mstrule)
        {
            try
            {
                DataSet ds = mastersService.Mstrule(mstrule);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }

        [HttpPost("Filetemplatefield")]
        public IActionResult Filetemplatefield([FromBody] Filetemplatefield filetemplatefield)
        {
            try
            {
                DataSet ds = mastersService.Filetemplatefield(filetemplatefield);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Filetemplate")]
        public IActionResult Filetemplate([FromBody] Filetemplate filetemplate)
        {
            try
            {
                DataSet ds = mastersService.Filetemplate(filetemplate);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Rulefield")]
        public IActionResult Rulefield([FromBody] Rulefield rulefield)
        {
            try
            {
                DataSet ds = mastersService.Rulefield(rulefield);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Applyrule")]
        public IActionResult Applyrule([FromBody] Applyrule applyrule)
        {
            try
            {
                DataSet ds = mastersService.Applyrule(applyrule);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Applyruledtl")]
        public IActionResult Applyruledtl([FromBody] Applyruledtl applyruledtl)
        {
            try
            {
                DataSet ds = mastersService.Applyruledtl(applyruledtl);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Applyrule_addcond")]
        public IActionResult Applyrule_addcond([FromBody] Applyrule_addcond Applyruleaddcond)
        {
            try
            {
                DataSet ds = mastersService.Applyrule_addcond(Applyruleaddcond);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Applyrule_targetgrpfield")]
        public IActionResult Applyrule_targetgrpfield([FromBody] Applyrule_targetgrpfield applyruletargetgrpfield)
        {
            try
            {
                DataSet ds = mastersService.Applyrule_targetgrpfield(applyruletargetgrpfield);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Applyrule_basesele")]
        public IActionResult Applyrule_basesele([FromBody] Applyrule_basesele applyrulebasesele)
        {
            try
            {
                DataSet ds = mastersService.Applyrule_basesele(applyrulebasesele);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                return Ok(serializedProduct);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Problem(title: ex.Message);
            }
        }
        [HttpPost("Applyrule_basefilter")]
        public IActionResult Applyrule_basefilter([FromBody] Applyrule_basefilter applyrulebaseselefilter)
        {
            try
            {
                DataSet ds = mastersService.Applyrule_basefilter(applyrulebaseselefilter);
                var serializedProduct = JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
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

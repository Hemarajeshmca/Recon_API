using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReconModels;
using ReconServiceLayer;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportingFileController : ControllerBase
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(knockoffController));
        SupportingFileService supportingFileService = new SupportingFileService();

        
    }
}

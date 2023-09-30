using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconModels;
using System.Data;
using static ReconModels.UserManagementModel;
using static ReconServiceLayer.UserManagementService;
using static ReconServiceLayer.MastersService;
using ReconServiceLayer;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QcdmasterController : ControllerBase
	{

		[HttpPost("QcdMasterRead")]
		public IActionResult QcdMasterRead(QcdmasterModel qcdmodel)
		{
			DataTable response = new DataTable();
			try
			{
				response = QcdmasterService.QcdMasterRead(qcdmodel);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("QcdMasterGridRead")]
		public IActionResult QcdMasterGridRead(Qcdgridread objgridread)
		{
			DataTable response = new DataTable();
			try
			{
				response = QcdmasterService.QcdMasterGridRead(objgridread);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("QcdMaster")]
		public IActionResult QcdMaster(mainQCDMaster objmaster)
		{
			DataTable response = new DataTable();
			try
			{
				response = QcdmasterService.QcdMasters(objmaster);
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

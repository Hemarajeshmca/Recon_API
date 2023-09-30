using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconModels;
using ReconServiceLayer;
using System.Data;
using static ReconModels.DatasetModel;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DatasetController : ControllerBase
	{
		[HttpPost("DatasetRead")]
		public IActionResult DatasetRead(Datasetlistmodel Datasetlistmodel)
		{
			DataTable response = new DataTable();
			try
			{
				response = DatasetService.DatasetRead(Datasetlistmodel);
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

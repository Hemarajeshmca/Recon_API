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
		[HttpPost("DatasetHeader")]
		public IActionResult DatasetHeader(DatasetHeadermodel Datasetheadermodel)
		{
			DataTable response = new DataTable();
			try
			{
				response = DatasetService.DatasetHeader(Datasetheadermodel);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[HttpPost("DatasetDetail")]
		public IActionResult DatasetDetail(Datasetdetailmodel Datasetdetailmodel)
		{
			DataTable response = new DataTable();
			try
			{
				response = DatasetService.DatasetDetail(Datasetdetailmodel);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[HttpPost("DatasetReaddetail")]
		public IActionResult DatasetReaddetail(Datasetdetailmodellist Datasetdetailmodellist)
		{
			DataTable response = new DataTable();
			try
			{
				response = DatasetService.DatasetReaddetail(Datasetdetailmodellist);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[HttpPost("getfieldtype")]
		public IActionResult getfieldtype()
		{
			DataTable response = new DataTable();
			try
			{
				response = DatasetService.getfieldtype();
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

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static ReconModels.RolesModel;
using static ReconModels.UserManagementModel;
using ReconServiceLayer;
using System.Data;

namespace Recon_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : Controller
	{
		private IConfiguration _configuration;
		public RolesController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";

		[HttpPost("Roles")]
		public IActionResult Roles(rolelistModel objrolelist)
		{
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = RolesService.rolelistService(objrolelist, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("Rolelist")]
		public IActionResult Rolelist()
		{
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = RolesService.roleService(header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("Rolefetch")]
		public IActionResult Rolefetch(RolefetchModel objRolefetchModel)
		{
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = RolesService.RolefetchService(objRolefetchModel, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}


		//pr_fetch_roledetails

		[HttpPost("Roledetails")]
		public IActionResult Roledetails(roledetailsModel objroledetailsModel)
		{
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = RolesService.RoledetailsService(objroledetailsModel, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}


		[HttpPost("saveRoleAccess")]
		public IActionResult saveRoleAccess(saveRoleAccessModel objsaveRoleAccessModel)
		{
			headerValue header_value = new headerValue();
			DataTable response = new DataTable();
			try
			{
				constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = RolesService.saveRoleAccessService(objsaveRoleAccessModel, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
        [HttpPost("saveRolePermissionAccess")]
        public IActionResult saveRolePermissionAccess(saveRoleAccessModel objsaveRoleAccessModel)
        {
            headerValue header_value = new headerValue();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = RolesService.saveRolePermissionsAccessService(objsaveRoleAccessModel, header_value, constring);
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

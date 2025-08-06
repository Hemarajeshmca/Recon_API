using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReconServiceLayer;
using static ReconModels.CommonModel;
using static ReconModels.UserManagementModel;
using System.Data;
using System.Linq;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private IConfiguration _configuration;
        public CommonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";
        [HttpPost("errorLog")]
        public void errorLog(errorlogModel objerrorlog)
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
                response = CommonService.Commonservice(objerrorlog, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                //return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                //return Problem(title: e.Message);
            }
        }

        [HttpPost("configvalue")]
        public IActionResult configvalue(configvalueModel objconfigvalue)
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
                response = CommonService.configvalueservice(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("roleconfig")]
        public IActionResult roleconfig(roleconfig objconfigvalue)
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
                response = CommonService.roleconfig_srv(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpPost("reconmindate")]
        public IActionResult reconmindate(reconmindate objconfigvalue)
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
                response = CommonService.reconmindate_srv(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("Schedulerupload")]
        public IActionResult Scheduleruploadfile(IFormFile file, string in_file_path, string initiated_by)
        {
            string msg = "";
            var src_filename = "";
            //try
            //{
            if (file != null && file.Length > 0)
            {
                if (!Directory.Exists(in_file_path))
                {
                    Directory.CreateDirectory(in_file_path);
                }
                src_filename = file.FileName;

                var targetFilePath = System.IO.Path.Combine(in_file_path, src_filename);
                using (var stream = new FileStream(targetFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                msg = "File uploaded and saved successfully...";
            }
            else
            {
                msg = "No file was uploaded.";
            }
            var serializedProduct = msg;
            return Ok(serializedProduct);
        }
        [HttpPost("GetFiles")]
        public IActionResult GetFiles(string folder_path)
        {
            string folderPath = folder_path;
            var directories = Directory.GetDirectories(folderPath)
                    .Select(dirPath => new FileSystemItem
                    {
                        Name = Path.GetFileName(dirPath),
                        FullPath = dirPath,
                        Type = "Folder",
                        Created = Directory.GetCreationTime(dirPath),
                        SizeBytes = null
                    });

            var files = Directory.GetFiles(folderPath)
                .Select(filePath => new FileSystemItem
                {
                    Name = Path.GetFileName(filePath),
                    FullPath = filePath,
                    Type = "File",
                    Created = System.IO.File.GetCreationTime(filePath),
                    SizeBytes = new FileInfo(filePath).Length
                });

            var result = directories.Concat(files).ToList();

            return Ok(result);
        }
        public class FileSystemItem
        {
            public string Name { get; set; }
            public string FullPath { get; set; }
            public string Type { get; set; } // "File" or "Folder"
            public DateTime Created { get; set; }
            public long? SizeBytes { get; set; } // Nullable: only used for files
        }

        // Hema checking
        // test2
        [HttpPost("Test")]
        public IActionResult Test()
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
                response = CommonService.TestService(header_value, constring);
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

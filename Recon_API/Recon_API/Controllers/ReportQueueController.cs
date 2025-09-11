using Microsoft.AspNetCore.Mvc;
using ReconModels;
using ReconServiceLayer;
using ReconServiceLayer.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;

namespace Recon_API.Controllers
{
    public class ReportQueueController : Controller
    {
        private readonly IReportQueueService _reportQueueService;
        private IConfiguration _configuration;
        DataTable response = new DataTable();
        DataSet ds = new DataSet();
        public ReportQueueController(IReportQueueService reportQueueService, IConfiguration configuration)
        {
            _reportQueueService = reportQueueService;
            _configuration = configuration;
        }


        [HttpPost("setReportqueue")]
        public IActionResult setReportqueue(ReportQueueModel.reportqueue objReportqueuemodel)
        {
            //constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            UserManagementModel.headerValue header_value = new UserManagementModel.headerValue();
            try
            {
                string jsonString = JsonConvert.SerializeObject(objReportqueuemodel);
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = _reportQueueService.setReportqueueservice(objReportqueuemodel, jsonString, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


        [HttpPost("setReportqueuewithdatamodel")]
        public IActionResult setReportqueuewithdatamodel(ReportQueueModel.DataModel objDataModel)
        {
            //constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            UserManagementModel.headerValue header_value = new UserManagementModel.headerValue();
            try
            {

                string jsonString = JsonConvert.SerializeObject(objDataModel);
                string rawJson = JsonConvert.SerializeObject(objDataModel.Dataset1);

                // clean up if double-serialized
                if (rawJson.StartsWith("\"["))
                {
                    rawJson = JsonConvert.DeserializeObject<string>(rawJson);
                }

                List<ReportQueueModel.reportqueue> mappedList =
                       JsonConvert.DeserializeObject<List<ReportQueueModel.reportqueue>>(rawJson);

                ReportQueueModel.reportqueue mappedModel = mappedList.FirstOrDefault();


                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = _reportQueueService.setReportqueueservice(mappedModel, jsonString, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("reportScheduler")]
        public IActionResult Reportscheduler()
        {
            UserManagementModel.headerValue header_value = new UserManagementModel.headerValue();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = _reportQueueService.getReportqueueservice(header_value);
                if (Convert.ToString(response.Rows[0]["queue_type"]) == "Report")
                {
                    ReportModel.DataModel objDataModel = JsonConvert.DeserializeObject<ReportModel.DataModel>(Convert.ToString(response.Rows[0]["ko_query"]));
                    if (objDataModel != null)
                    {
                        List<ReportQueueModel.reportqueue> objReportqueuemodel =
                        JsonConvert.DeserializeObject<List<ReportQueueModel.reportqueue>>(objDataModel.Dataset1);

                        if (objReportqueuemodel != null) {
                            string constring = _configuration.GetConnectionString("DefaultConnection");
                            if (objReportqueuemodel[0].in_outputfile_type.ToLower() == "xlsx")
                            {
                                 ReportService.generatedynamicReportservice_new(objDataModel, constring, header_value);
                            }else if(objReportqueuemodel[0].in_outputfile_type.ToLower() == "csv")
                            {
                                ReportService.generatedynamicReportservice_new(objDataModel, constring, header_value);
                            }
                        }
                    }
                    else
                    {
                        //return Ok();
                    }
                }
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;
using Microsoft.Identity.Web.Resource;

namespace WebApiAngularAdDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:scopes")]
    public class ReportController : ControllerBase
    {
        [Authorize(Roles = "Manager")]
        [HttpGet("[action]")]
        public IActionResult GetReport()
        {
            return File(System.IO.File.ReadAllBytes(@"D:\Shailendra\Angular\Azure07062023\SampleReport.pdf"), "application/pdf");
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult GetReportStatus()
        {
            return Ok(new { Status = @"Report Generated at - " + DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") });
        }
    }
}

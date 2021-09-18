using ConnectingPlusAPI.Data;
using ConnectingPlusAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IReportRepository _report;
        public ReportsController(IReportRepository report)
        {
            _report = report;
        }
        [HttpPost()]
        public ActionResult<Report> CreateReport(Report report)
        {
            _report.CreateReport(report);
            return(Ok());
        }
        [HttpPost("{id}/{income}")]
        public ActionResult<string> KeepTrack(int income, Guid id)
        {
            _report.KeepTrack(id, income);
            return Ok();
        }
    }
}

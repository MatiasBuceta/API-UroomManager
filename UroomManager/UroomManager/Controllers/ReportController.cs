using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UroomManager.Entities;
using UroomManager.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UroomManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private ReservationService reservationService;
        public ReportController()
        {
            reservationService = new ReservationService();
        }


        // POST api/<ReportController>
        [Route("ReservationReport")]
        [HttpPost]
        ///public void ReservationReportPost([FromBody] string startdate, string enddate)
        public IEnumerable<ReservationReport> ReservationReportPost([FromBody] ReportDateEntry reportdataentry)
        {
            List<ReservationReport> reportlst= reservationService.reservationReport(reportdataentry);
            return reportlst;
        }

    }
}

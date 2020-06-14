using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Reporting;
using Telerik.Reporting.Processing;

namespace Membership.Controllers
{
    public class ReportController : Controller
    {

        public ActionResult Table(int status)
        {
            ViewBag.status = status;
            return View("MembersTable");
        }

        [HttpGet]
        public ActionResult Report(int status = -1)
        {
            //ViewBag.status = status;
            //return View("MembersReport");
            ReportProcessor reportProcessor = new ReportProcessor();
            Hashtable deviceInfo = new Hashtable();
            UriReportSource rs = new UriReportSource();
            rs.Parameters.Add("status", status);
            rs.Uri = "Reports/MembersReport.trdp";
            var res = reportProcessor.RenderReport("xlsx", rs, deviceInfo);
            var documentName = "MembersReport.xlsx";

            return File(res.DocumentBytes, res.MimeType, documentName);
        }
    }
}
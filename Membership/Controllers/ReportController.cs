using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Membership.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Table()
        {
            return View("MembersTable");
        }

        public ActionResult Report()
        {
            return View("MembersReport");
        }
    }
}
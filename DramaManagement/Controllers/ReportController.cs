using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DramaManagement.Models;

namespace DramaManagement.Controllers
{
    public class ReportController : Controller
    {
        DramaBDEntities db=new DramaBDEntities();


        // GET: Report


        public ActionResult GetReport()
        {
            var data = db.DramaDetails.ToList();

            ReportDocument rd=new ReportDocument();
            string reportPath = Server.MapPath("~/Reports/DramaReportsInfo.rpt");
            
            rd.Load(reportPath);
            rd.SetDataSource(data);

            Stream file = rd.ExportToStream(ExportFormatType.PortableDocFormat);

            return File(file,"application/pdf","Drama Report.pdf");
        }
    }
}
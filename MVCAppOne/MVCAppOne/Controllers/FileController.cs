using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppOne.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Download()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Content/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "simplefile.pdf");
            string fileName = "simplefile.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);            
        }
    }
}
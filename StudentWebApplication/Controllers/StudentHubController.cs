using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWebApplication.Controllers
{
    public class StudentHubController : Controller
    {
        // GET: StudentHub
        public ActionResult Index()
        {
            return View();
        }
    }
}
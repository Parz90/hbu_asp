using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult fahren()
        {
            return Content("Ich fahre gerade!!!");
        }

        public ActionResult schalteInGang(int gang)
        {
            return HttpNotFound("Nicht gefunden bla bla bla.....");
        }

        public ActionResult Create()
        {
            return View("View77");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serie_1___Aufgabe_2___Controller.Controllers
{
    public class LastwagenController : Controller
    {
        // GET: Lastwagen
        public ActionResult Index()
        {
            return View();
        }

        [Route("Lastwagen/Stop/{sekunden}")]
        public ActionResult Stop(int sekunden)
        {
            ViewBag.Sekunden = sekunden;
            return View();
        }
    }
}
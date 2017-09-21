using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProject1.Controllers
{
    public class LastwagenController : Controller
    {
        // GET: Lastwagen
        public ActionResult Index()
        {
            return View();
        }

        [Route("Lastwagen/Stop/{sekunden}")]
        public string Stop(int sekunden)
        {
            if (sekunden < 10)
            {
                return "Der Lastwagen wird in 7 Sekunden eine Notbremse ausführen.";
            }
            else
            {
                return "Der Lastwagen wird in 20 Sekunden anhalten.";
            }
        }
    }
}
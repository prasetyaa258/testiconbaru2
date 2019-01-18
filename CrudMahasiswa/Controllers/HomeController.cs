using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMahasiswa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Podo Moro Group";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Podo Moro University";

            return View();
        }
    }
}
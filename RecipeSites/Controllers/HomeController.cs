using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeSites.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Sweety Recipes | 2023";
            return View();
        }

        public ActionResult Slider()
        {
            ViewBag.Title = "Sweety Recipes | 2023";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Title = "Sweety Recipes | 2023";
            return View();
        }
        public ActionResult Blog()
        {

            return View();
        }
    }
}
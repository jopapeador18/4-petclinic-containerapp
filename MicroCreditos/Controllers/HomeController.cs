using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroCreditos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Variables = new Dictionary<string, string>();
            ViewBag.DevelopmentMode = false;

            var vars = Environment.GetEnvironmentVariables();

            foreach (DictionaryEntry item in vars)
            {
                ViewBag.Variables.Add(item.Key.ToString(), item.Value.ToString());
            }

            return View();
        }
    }
}

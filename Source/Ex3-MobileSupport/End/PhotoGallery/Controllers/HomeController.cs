using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Script.Serialization;
using PhotoGallery.Models;

namespace PhotoGallery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new HttpClient();
            var response = client.Get(Url.Action("gallery", "photo", null, Request.Url.Scheme));

            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<List<Photo>>(response.Content.ReadAsString());           

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
    }
}

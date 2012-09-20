using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PhotoGallery.Models;

namespace PhotoGallery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new HttpClient();
            var response = client.GetAsync(Url.Action("gallery", "photo", null, Request.Url.Scheme)).Result;
            var value = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<List<Photo>>(value);

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

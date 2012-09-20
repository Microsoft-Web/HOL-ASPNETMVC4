using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PhotoGallery.Models;
using System.Threading.Tasks;
using System.Threading;

namespace PhotoGallery.Controllers
{
    public class HomeController : AsyncController
    {
        [AsyncTimeout(500)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(Url.Action("gallery", "photo", null, Request.Url.Scheme), cancellationToken);
            var value = await response.Content.ReadAsStringAsync();
            var result = await JsonConvert.DeserializeObjectAsync<List<Photo>>(value);

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

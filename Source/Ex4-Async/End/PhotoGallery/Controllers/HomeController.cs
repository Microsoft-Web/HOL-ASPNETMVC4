using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Script.Serialization;
using PhotoGallery.Models;
using System.Threading.Tasks;
using System.Threading;

namespace PhotoGallery.Controllers
{
    public class HomeController : AsyncController
    {
        [AsyncTimeout(500)]
        [HandleError(ExceptionType = typeof(TaskCanceledException), View = "TimedOut")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var photosRequest = new HttpRequestMessage(HttpMethod.Get, Url.Action("gallery", "photo", null, Request.Url.Scheme));
            var response = await client.SendAsync(photosRequest, cancellationToken);
            
            var jss = new JavaScriptSerializer();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = jss.Deserialize<List<Photo>>(responseString);

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

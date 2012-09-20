using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Controllers
{
    public class PhotoController : Controller
    {
        public ActionResult Gallery()
        {
            System.Threading.Thread.Sleep(1000);

            return this.File("~/App_Data/Photos.json", "application/json");
        }
    }
}

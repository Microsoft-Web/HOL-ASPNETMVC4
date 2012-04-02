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
            return this.File("~/App_Data/Photos.json", "application/json");
        }
    }
}
using Business.Concrete;
using DataAccess.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class GalleryController : Controller
    {
        ImageManager ımageManager = new ImageManager(new ImageDal());
        public ActionResult Index()
        {
            return View(ımageManager.GetAll());
        }
    }
}
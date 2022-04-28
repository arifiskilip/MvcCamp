using Business.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new ContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(Content content)
        {
            return View(contentManager.GetListById(content.Id));
        }
    }
}
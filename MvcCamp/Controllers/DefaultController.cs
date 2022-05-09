using Business.Concrete;
using DataAccess.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new HeadingDal());
        ContentManager contentManager = new ContentManager(new ContentDal());
        public ActionResult Headings()
        {
            return View(headingManager.GetAllHeadingStatus(true));
        }
        public PartialViewResult Index(int id = 0)
        {
            return PartialView(contentManager.GetListByHeadingId(id));
        }
    }
}
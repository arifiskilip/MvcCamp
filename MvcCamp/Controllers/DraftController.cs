using Business.Concrete;
using DataAccess.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class DraftController : Controller
    {
        DraftManager draftManager = new DraftManager(new DraftDal());
        public ActionResult Index()
        {
            return View(draftManager.GetAll());
        }
    }
}
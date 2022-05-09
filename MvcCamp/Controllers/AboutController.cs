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
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new AboutDal());
        public ActionResult Index()
        {
            return View(aboutManager.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(About about)
        {
            aboutManager.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult partialAdd()
        {
            return PartialView();
        }

        public ActionResult StatuActive(About about)
        {
            var result = aboutManager.GetById(about.Id);
            result.Statu = true;
            aboutManager.Update(result);
            return RedirectToAction("Index");
        }
        public ActionResult StatuPassive(About about)
        {
            var result = aboutManager.GetById(about.Id);
            result.Statu = false;
            aboutManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}
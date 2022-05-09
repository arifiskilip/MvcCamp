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
    public class HomeController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        HeadingManager headingManager = new HeadingManager(new HeadingDal());
        WriterManager writerManager = new WriterManager(new WriterDal());
        ContactManager contactManager = new ContactManager(new ContactDal());
        public ActionResult HomePage()
        {
            ViewBag.NumberOfHeading = headingManager.NumberOfHeading();
            ViewBag.numberOfCategories = categoryManager.NumberOfCategories();
            ViewBag.numberOfWriters = writerManager.NumberOfWriters();
            ViewBag.numberOfContacts = contactManager.NumberOfContacts();
            return View();
        }
    }
}
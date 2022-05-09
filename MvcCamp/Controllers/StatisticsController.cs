using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        HeadingManager headingManager = new HeadingManager(new HeadingDal());
        WriterManager writerManager = new WriterManager(new WriterDal());
        // GET: Statistics
        public ActionResult Index()
        {
            ViewBag.numberOfCategories = categoryManager.NumberOfCategories();
            ViewBag.howMonyCategoriesOfSoftware = headingManager.HowMonyCategoriesOfSoftware();
            ViewBag.nameStartingWithA = writerManager.NameStartingWithA();
            ViewBag.categoryNameWithMostTitles = headingManager.CategoryNameWithMostTitles();
            ViewBag.differenceBetweenStatus = categoryManager.DifferenceBetweenStatus();
            return View();
        }

    
    }
}
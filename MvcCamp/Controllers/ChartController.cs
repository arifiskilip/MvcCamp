using Business.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class ChartController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        WriterManager writerManager = new WriterManager(new WriterDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }

        public List<WriterDto> WriterList()
        {
            var results = writerManager.GetWriterListDto();

            return results;
        }
        public List<CategoryDto> CategoryList()
        {
            var results = categoryManager.GetCategoryListDto();

            return results;
        }
    }
}
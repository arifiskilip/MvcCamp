using Business.Concrete;
using Business.ValidationRule;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new HeadingDal());
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        WriterManager writerManager = new WriterManager(new WriterDal());
        HeadingValidator headingValidator= new HeadingValidator();
        ValidationResult result = new ValidationResult();

        // GET: Heading
        public ActionResult Index(int p=1)
        {
            return View(headingManager.GetAll().ToPagedList(p,5));
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> valueCategory = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Value = c.Id.ToString(),
                                                      Text = c.Name
                                                  }).ToList() ;
            List<SelectListItem> valueWriter = (from w in writerManager.GetAll()
                                                select new SelectListItem
                                                {
                                                    Value = w.Id.ToString(),
                                                    Text = w.FirstName + " " + w.LastName
                                                }).ToList();
            ViewBag.valueCategory = valueCategory;
            ViewBag.valueWriter = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            result=headingValidator.Validate(heading);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            heading.Date = DateTime.Now;
            headingManager.Add(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> selectListItems = (
                from x in categoryManager.GetAll()
                select new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            ViewBag.valueHeading = selectListItems;
            return View(headingManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            
            result = headingValidator.Validate(heading);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            headingManager.Update(heading);
            return RedirectToAction("Index");            
        }
        public ActionResult Delete(Heading heading)
        {
            var headingValue = headingManager.GetById(heading.Id);
            headingValue.Statu = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("Index");
        }

        public ActionResult Report()
        {
            return View(headingManager.GetAll());
        }
    }
}
using Business.Concrete;
using Business.ValidationRule;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new WriterDal());
        WriterValidator writerValidator = new WriterValidator();
        ValidationResult result = new ValidationResult();

        public ActionResult Index()
        {
            return View(writerManager.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Writer writer)
        {
            result = writerValidator.Validate(writer);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            writerManager.Add(writer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = writerManager.GetById(id);
            return View(result);
        }

        public ActionResult Update(Writer writer)
        {
            var result = writerValidator.Validate(writer);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            writerManager.Update(writer);
            return RedirectToAction("Index");
        }
    }
}
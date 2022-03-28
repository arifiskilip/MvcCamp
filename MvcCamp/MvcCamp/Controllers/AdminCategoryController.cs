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
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();
        ValidationResult resultValidator = new ValidationResult();
        // GET: Admin
        public ActionResult Index()
        {
            return View(categoryManager.GetAll());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            resultValidator = categoryValidator.Validate(category);
            if (!resultValidator.IsValid)
            {
                foreach (var item in resultValidator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);                   
                }
                return View();
            }
            categoryManager.Add(category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Category category)
        {
            categoryManager.Delete(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {          
            return View(categoryManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            resultValidator = categoryValidator.Validate(category);
            if (!resultValidator.IsValid)
            {
                foreach (var item in resultValidator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }
    }
}
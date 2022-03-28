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
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();
        ValidationResult result =new ValidationResult();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
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
            result = categoryValidator.Validate(category);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            categoryManager.Add(category);
            return RedirectToAction("GetAll");
        }
    }
}
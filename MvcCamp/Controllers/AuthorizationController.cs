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
    public class AuthorizationController : Controller
    {
        LoginManager loginManager = new LoginManager(new LoginDal());
        public ActionResult Index()
        {
            return View(loginManager.GetAll());
        } 
        public ActionResult StatuActive(Admin admin)
        {
            var result = loginManager.GetById(admin.Id);
            result.Statu = true;
            loginManager.Update(result);
            return RedirectToAction("Index");
        }
        public ActionResult StatuPassive(Admin admin)
        {
            var result = loginManager.GetById(admin.Id);
            result.Statu = false;
            loginManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}

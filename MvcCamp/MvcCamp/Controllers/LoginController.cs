using Business.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCamp.Controllers
{
    public class LoginController : Controller
    {
        LoginManager loginManager = new LoginManager(new LoginDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //foreach (var item in loginManager.GetAll())
            //{
            //    if (admin.UserName == loginManager.DecryptToPassword(admin).UserName &&
            //    admin.Password == loginManager.DecryptToPassword(admin).Password)
            //    {
            //        return RedirectToAction("Register");
            //    }
            //}
            if (admin.UserName=="arif" && admin.Password=="arif")
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["UserName"] = admin.UserName;
                return RedirectToAction("Index","Category");
            }

            return View();                 
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Admin admin)
        {
            loginManager.Add(admin);
            return RedirectToAction("Index");
        }
    }
}
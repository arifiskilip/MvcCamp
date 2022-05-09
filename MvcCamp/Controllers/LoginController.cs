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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LoginManager loginManager = new LoginManager(new LoginDal());
        WriterManager writerManager = new WriterManager(new WriterDal());

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

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            return View(loginManager.GetById(id));
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            loginManager.Update(admin);
            return RedirectToAction("Index", "Authorization");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var result = writerManager.GetAll().Find(x=> x.Email==writer.Email && x.Password == writer.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(writer.Email, false);
                Session["Email"] = writer.Email;
                return RedirectToAction("MyHeading", "WriterPanel");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}
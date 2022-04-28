using Business.Concrete;
using Business.ValidationRule;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new ContactDal());
        MessageManager messageManager = new MessageManager(new MessageDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            return View(contactManager.GetAll());
        }

        public ActionResult GetContactDetail(Contact contact)
        {
            var result = contactManager.GetById(contact.Id);
            result.State = false;
            contactManager.Update(result);
            return View(result);
        }

        public PartialViewResult GetMenuBar()
        {
            ViewBag.NumberOfIncomingMessage= contactManager.GetAll().Count().ToString();
            ViewBag.NumberOfCommunication = messageManager.GetListInbox().Count().ToString();
            ViewBag.NumberOfReadMessage= contactManager.GetListReadMessage().Count().ToString();
            ViewBag.NumberOfUnreadMessage= contactManager.GetListUnreadMessage().Count().ToString();
            return PartialView();
        }
        public ActionResult GetReadMessage()
        {
            return View(contactManager.GetListReadMessage());
        }

        public ActionResult GetUnreadMessage()
        {
            return View(contactManager.GetListUnreadMessage());
        }
    }
}
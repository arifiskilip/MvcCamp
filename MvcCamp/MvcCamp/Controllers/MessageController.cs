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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new MessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            return View(messageManager.GetListInbox());
        }

        public ActionResult Sendbox()
        {
            return View(messageManager.GetListSendbox());
        }
        
        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Now;
                messageManager.Add(message);
                return RedirectToAction("GetSendboxDetail");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult GetInboxtDetail(Message message)
        {
            var result = messageManager.GetById(message.Id);
            return View(result);
        }

        public ActionResult GetSendboxDetail(Message message)
        {
            var result = messageManager.GetById(message.Id);
            return View(result);
        }
    }
}
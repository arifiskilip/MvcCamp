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
    [Authorize]
    public class WriterPanelController : Controller
    {
        MessageManager messageManager = new MessageManager(new MessageDal());
        HeadingManager headingManager = new HeadingManager(new HeadingDal());
        ContentManager contentManager = new ContentManager(new ContentDal());
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        WriterManager writerManager = new WriterManager(new WriterDal());
        HeadingValidator headingValidator = new HeadingValidator();
        ValidationResult result = new ValidationResult();
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult WriterProfile(int id=0)
        {
            
            string email = (string)Session["EMail"];
            id = writerManager.GetAll().Where(w => w.Email == email)
                 .Select(w => w.Id).FirstOrDefault();
            return View(writerManager.GetById(id));
        }

        [HttpGet]
        public ActionResult WriterEdit(int id)
        {
            return View(writerManager.GetById(id));
        }

        [HttpPost]
        public ActionResult WriterEdit(Writer writer)
        {
         
            writerManager.Update(writer);
            return RedirectToAction("WriterProfile");
        }
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["EMail"];
            var writerInfo = writerManager.GetAll().Where(w => w.Email == p)
                .Select(w => w.Id).FirstOrDefault();
            return View(headingManager.GetAllHeadingByWriter(writerInfo));
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Value = c.Id.ToString(),
                                                      Text = c.Name
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading,string p)
        {
            p = (string)Session["EMail"];
            var writerId = writerManager.GetAll().Where(w => w.Email == p)
                .Select(w => w.Id).FirstOrDefault();

            result = headingValidator.Validate(heading);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            heading.Date = DateTime.Now;
            heading.WriterId = writerId;
            heading.Statu = true;
            headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(Heading heading)
        {
            var result = headingManager.GetById(heading.Id);
            result.Statu = false;
            headingManager.Update(result);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> selectListItems = (
                from x in categoryManager.GetAll()
                select new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            ViewBag.valueHeading = selectListItems;
            var result = headingManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult WriterInbox()
        {
           string email = (string)Session["EMail"];
            return View(messageManager.GetListInbox(email));
        }

        public ActionResult GetWriterDetailInbox(Writer writer)
        {
            return View(messageManager.GetById(writer.Id));
        }

        public ActionResult WriterSendbox()
        {
            string email = (string)Session["EMail"];
            return View(messageManager.GetListSendbox(email));
        }
        public ActionResult GetWriterDetailSendbox(Writer writer)
        {
            return View(messageManager.GetById(writer.Id));
        }

        public PartialViewResult Menu()
        {
            return PartialView();
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
            string sender = (string)Session["EMail"];
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Now;
                message.SenderMessage = sender;
                messageManager.Add(message);
                return RedirectToAction("WriterSendbox");
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

        public ActionResult WriterContent(string p)
        {
            p = (string)Session["EMail"];
            var writerInfo = writerManager.GetAll().Where(w => w.Email == p)
                .Select(w => w.Id).FirstOrDefault();
            var contentValue = contentManager.GetListByWriterId(writerInfo);
            return View(contentValue);
        }

        public ActionResult AllHeading()
        {
            return View(headingManager.GetAll());
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["EMail"];
            var writerIdInfo = writerManager.GetAll().Where(w => w.Email == mail)
                .Select(w => w.Id).FirstOrDefault();
            content.Date = DateTime.Now;
            content.WriterId = writerIdInfo;
            contentManager.Add(content);
            return RedirectToAction("MyHeading");
        }
    }
}
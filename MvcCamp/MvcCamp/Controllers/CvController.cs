using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class CvController : Controller
    {
        // GET: Cv
        public ActionResult Index()
        {
            DictionaryContext context = new DictionaryContext();
            var result = context.CvUserInfos.FirstOrDefault(x => x.Id == 1);
            var ListSkill = context.CvSkills.Where(x => x.UserId == 1).ToList();
            return View(Tuple.Create(result,ListSkill));
        }

        [HttpGet]
        public ActionResult EditProfile(int id=1)
        {
            DictionaryContext context = new DictionaryContext();
            var result = context.CvUserInfos.SingleOrDefault(x => x.Id == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult EditProfile(CvUserInfo cvUserInfo)
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var updated = context.CvUserInfos.FirstOrDefault(x => x.Id == 1);
                updated.Firstname = cvUserInfo.Firstname;
                updated.Lastname = cvUserInfo.Lastname;
                updated.Age = cvUserInfo.Age;
                updated.School = cvUserInfo.School;
                updated.Department = cvUserInfo.Department;
                context.SaveChanges();
                return RedirectToAction("Index");
            }            
        }
        public ActionResult Skills()
        {
            DictionaryContext context = new DictionaryContext();
            var result = context.CvSkills.Where(x => x.UserId == 1).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult SkillAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SkillAdd(CvSkill cvSkill)
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                CvSkill skill = new CvSkill();
                skill.UserId = 1;
                skill.SkillName = cvSkill.SkillName;
                skill.SkillPoint = cvSkill.SkillPoint;
                context.CvSkills.Add(skill);
                context.SaveChanges();
                return RedirectToAction("Skills");
            }
        }

        public ActionResult SkillDelete(CvSkill cvSkill)
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = context.CvSkills.FirstOrDefault(x => x.Id == cvSkill.Id);
                context.CvSkills.Remove(result);
                context.SaveChanges();
                return RedirectToAction("Skills");
            }
        }

        [HttpGet]
        public ActionResult SkillUpdate(int id)
        {
            DictionaryContext context = new DictionaryContext();
            var result = context.CvSkills.FirstOrDefault(x => x.Id == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult SkillUpdate(CvSkill cvSkill)
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var updated = context.CvSkills.FirstOrDefault(x => x.Id == cvSkill.Id);
                updated.SkillName = cvSkill.SkillName;
                updated.SkillPoint = cvSkill.SkillPoint;
                context.SaveChanges();
                return RedirectToAction("Skills");
            }
        }
    }
}
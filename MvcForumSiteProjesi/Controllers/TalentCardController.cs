using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    public class TalentCardController : Controller
    {
        private TalentCardManager talentCardManager = new TalentCardManager(new EfTalentCardDal());
        public ActionResult Index()
        {
            var result = talentCardManager.GetAll();
            return View(result);
        }

        public ActionResult TalentCard()
        {
            var result = talentCardManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(TalentCard talent)
        {
            talentCardManager.Add(talent);
            return RedirectToAction("TalentCard");
        }

        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var result = talentCardManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateTalent(TalentCard talent)
        {
            talentCardManager.Update(talent);
            return RedirectToAction("TalentCard");
        }


        public ActionResult DeleteTalent(int Id)
        {
            var result = talentCardManager.GetById(Id);
            talentCardManager.Delete(result);
            return RedirectToAction("TalentCard");
        }
    }
}
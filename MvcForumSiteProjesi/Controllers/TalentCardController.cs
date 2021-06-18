using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}
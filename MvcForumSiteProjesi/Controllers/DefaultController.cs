using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        //layout olarak kullandım
        public ActionResult Headings()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }

        public PartialViewResult Index(int id = 0)
        {
            var contentValues = contentManager.GetListByHeadingId(id);
            return PartialView(contentValues);
        }
    }
}
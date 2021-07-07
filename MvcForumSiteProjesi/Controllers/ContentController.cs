using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string searching)
        {
            var values = contentManager.GetList();
            var searchingValues = contentManager.GetList(searching);
            if (!string.IsNullOrEmpty(searching))
            {
                return View(searchingValues);
            }

            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var categoryValue = contentManager.GetListByHeadingId(id);
            return View(categoryValue);
        }
    }
}
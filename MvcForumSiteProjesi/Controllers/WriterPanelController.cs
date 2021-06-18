using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string headingMail)
        {
            headingMail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == headingMail).Select(z => z.WriterId).FirstOrDefault();
            var myHeadingValue = headingManager.GetListByWriter(writerIdInfo);
            return View(myHeadingValue);
        }

        //yeni başlık ekleme
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from category in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryNameView = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMailInfo).Select(z => z.WriterId).FirstOrDefault();

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo; //writerIdInfo
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }

        //başlık düzenleme işlemleri
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValues = (from category in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = category.CategoryName,
                                                       Value = category.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categoryNameView = categoryValues;
            var headingValue = headingManager.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        //silme işlemi
        public ActionResult DeleteHeading(int id)
        {
            var myHeadingValue = headingManager.GetByID(id);
            myHeadingValue.HeadingStatus = false;
            headingManager.HeadingDelete(myHeadingValue);
            return RedirectToAction("MyHeading");
        }
    }
}
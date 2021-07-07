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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            //dropdownlist ile kategori isimlerini ilişkili tabloya uygun şekilde çekmek için yazdık
            List<SelectListItem> categoryValues = (from category in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = category.CategoryName, //kategori adı
                                                       Value = category.CategoryId.ToString() //kategori adlarının arka plandaki id leri
                                                   }).ToList();

            List<SelectListItem> writerValues = (from writer in writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = writer.WriterName + " " + writer.WriterSurname,
                                                     Value = writer.WriterId.ToString()
                                                 }).ToList();

            ViewBag.categoryNameView = categoryValues;
            ViewBag.writerNameView = writerValues;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByID(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }

    }
}
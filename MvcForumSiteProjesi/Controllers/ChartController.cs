using DataAccessLayer.Concrete;
using MvcForumSiteProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryPieChart()
        {
            return View();
        }

        public ActionResult HeadingPieChart()
        {
            return View();
        }

        public ActionResult WriterColumnChart()
        {
            return View();
        }

        public ActionResult TalentLineChart()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName ="Yazılım",
                CategoryCount = 8
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Kitap",
                CategoryCount = 3
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 14
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 7
            });
            return categoryClasses;
        }

        ////dinamik category charts
        //public ActionResult CategoryCharts()
        //{
        //    return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult CategoryList()
        //{
        //    List
        //}

        //dinamik writer charts
        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }
        public List<WriterChart> WriterList()
        {
            List<WriterChart> writersChart = new List<WriterChart>();
            using (Context context = new Context())
            {
                writersChart = context.Writers.Select(x => new WriterChart()
                {
                    WriterName = x.WriterName,
                    WriterCount = x.Headings.Count()
                }).ToList();
            }
            return writersChart;
        }

        //dinamik heading charts
        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingChart> HeadingList()
        {
            List<HeadingChart> headingCharts = new List<HeadingChart>();
            using(Context context = new Context())
            {
                headingCharts = context.Headings.Select(x => new HeadingChart()
                {
                    HeadingName = x.HeadingName,
                    ContentCount = x.Contents.Count()
                }).ToList();
            }
            return headingCharts;
        }

    }
}
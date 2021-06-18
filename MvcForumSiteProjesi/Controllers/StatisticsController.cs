using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    //istatistik verilerime ulaşıp sayfama cekmek için oluşturduğum controller
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context context = new Context();
        public ActionResult Index()
        {
            var totalCategory = context.Categories.Count().ToString(); //toplam kategori sayısı
            ViewBag.totalCategory = totalCategory;

            var titleCount = context.Headings.Count(c => c.CategoryId == 6).ToString();   //Başlık tablosunda "dizi" kategorisine ait başlık sayısı
            ViewBag.titleCount = titleCount;

            var isA = (from c in context.Writers select c.WriterName.ToLower().IndexOf("a")).Count().ToString(); //Yazar adında 'a' harfi geçen yazar sayısı
            ViewBag.isA = isA;

            //En fazla başlığa sahip kategori adı
            var maxHeading = context.Categories.Where(x => x.CategoryId == context.Headings.GroupBy(c => c.CategoryId).OrderByDescending(c => c.Count()).Select(c => c.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.maxHeading = maxHeading;

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var difference = context.Categories.Count(context => context.CategoryStatus == true) - context.Categories.Count(context => context.CategoryStatus == false);
            ViewBag.difference = difference;

            return View();
        }
    }
}
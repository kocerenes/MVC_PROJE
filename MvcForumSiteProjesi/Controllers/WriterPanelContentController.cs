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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();

        public ActionResult MyContent(string writerMail)
        {
            
            writerMail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMail).Select(y=> y.WriterId).FirstOrDefault();
            
            var contentValue = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValue);
        }

        //writer olarak giren birisinin başlıklara içerik eklemesi
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string writerMail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterId).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }

        //yapılıcaklar listesi
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}
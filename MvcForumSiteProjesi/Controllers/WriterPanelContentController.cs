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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult MyContent(string writerMail)
        {
            Context context = new Context();
            writerMail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMail).Select(y=> y.WriterId).FirstOrDefault();
            
            var contentValue = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValue);
        }
    }
}
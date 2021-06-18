using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery

        ImageFileManager ImageFile = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = ImageFile.GetList();
            return View(files);
        }
    }
}
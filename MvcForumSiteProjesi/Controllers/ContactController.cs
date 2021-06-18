using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidate = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}
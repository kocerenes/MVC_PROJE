using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForumSiteProjesi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidations = new MessageValidator();

        public ActionResult Inbox()
        {
            string writerMail = (string)Session["WriterMail"];
            var messageValues = messageManager.GetListInbox(writerMail);
            return View(messageValues);
        }

        //Gönderilen mesajlar
        public ActionResult Sendbox()
        {
            string writerMail = (string)Session["WriterMail"];
            var messageValues = messageManager.GetListSendbox(writerMail);
            return View(messageValues);
        }

        //gelen mesaj detayları/içeriği
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var Values = messageManager.GetById(id);
            return View(Values);
        }

        //gönderilen mesaj detayları/içeriği
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var Values = messageManager.GetById(id);
            return View(Values);
        }

        //yeni mesaj olusturma

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messageValidations.Validate(message);

            string senderMail = (string)Session["WriterMail"];

            if (results.IsValid)
            {
                message.SenderMail = senderMail;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        //partialview
        public PartialViewResult MessageListPartial()
        {
            return PartialView();
        }

    }
}
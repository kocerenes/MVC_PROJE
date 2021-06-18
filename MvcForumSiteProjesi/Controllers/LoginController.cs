using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcForumSiteProjesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Admin

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            //hashleme
            //SHA1 sha1 = new SHA1CryptoServiceProvider();
            //string password = admin.AdminPassword;
            //string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            //admin.AdminPassword = result;
            //hashleme

            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //yazar login işlemi
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //hashleme
            //SHA1 sha1 = new SHA1CryptoServiceProvider();
            //string password = writer.WriterPassword;
            //string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            //writer.WriterPassword = result;
            //hashleme


            Context context = new Context();
            var writerUserInfo = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            //ben robot değilim
            var response = Request["g-recaptcha-response"];
            const string secret = "6LdQqz8bAAAAABRDLAjSP0NrRWZTD3CynIuUqkkq";
            var client = new WebClient();

            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            if (!captchaResponse.Success)
            {
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                return View();
            }
            //ben robot değilim


            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }
    }
}
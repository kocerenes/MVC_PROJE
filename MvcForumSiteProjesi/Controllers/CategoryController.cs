using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
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
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            //categoryManager.CategoryAddBL(category);

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);

            if (results.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");//ekleme işlemi tamamlandıktan sonra GetCategoryList aksiyonuna yönlendirdik.
            }
            else
            {
                foreach (var result in results.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }
            }

            return View();
        }
    }
}
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }


        //GenericRepository<Category> genericRepository = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //{
        //    return genericRepository.List();
        //}

        //public void CategoryAddBL(Category category)
        //{
        //    if(category.CategoryName == "" || category.CategoryName.Length <=3 || category.CategoryDescription == "" || category.CategoryName.Length >= 51)
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        genericRepository.Insert(category);
        //    }
        //}

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
    }
}

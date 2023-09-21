using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concret
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _icategoryDal;

        public CategoryManager(ICategoryDal icategoryDal)
        {
            _icategoryDal = icategoryDal;
        }
        public List<Category> GetList()
        {
            return _icategoryDal.GetListAll();
        }
        public Category TGetById(int id)
        {
            return _icategoryDal.GetById(id);
        }

        public void TAdd(Category t)
        {
            _icategoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _icategoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _icategoryDal.Update(t);
        }
    }
}

using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.Concrete;
using SellingSites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Concrete
{
    public class MultiCategoryManager : IMultiCategoryService
    {
        private IMultiCategoryDal _categoryDal;
        public MultiCategoryManager(IMultiCategoryDal multiCategoryDal)
        {
            _categoryDal = multiCategoryDal;
        }
        public void Add(MultiCategory multiCategory)
        {
            _categoryDal.Add(multiCategory);
        }

        public void Delete(int productId, int categoryId)
        {
            _categoryDal.Delete(new MultiCategory { ProductId = productId , CategoryId = categoryId });
        }

        public void Update(MultiCategory multiCategory)
        {
            _categoryDal.Update(multiCategory);
        }
    }
}

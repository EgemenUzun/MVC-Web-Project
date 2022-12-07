using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface IMultiCategoryService
    {
        void Add(MultiCategory multiCategory);
        void Update(MultiCategory multiCategory);
        void Delete(int productId,int categoryId);
    }
}

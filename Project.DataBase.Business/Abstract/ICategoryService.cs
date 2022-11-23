using Project.DataBase.Entities.Concrete;
using SellingSites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}

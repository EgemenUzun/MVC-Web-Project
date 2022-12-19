using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Concrete
{
    public class TopCustomerForTopProductManager : ITopCustomerForTopProductService
    {
        ITopCustomerForTopProductDal _topCustomerForTopProductDal;
        public TopCustomerForTopProductManager(ITopCustomerForTopProductDal topCustomerForTopProductDal)
        {
            _topCustomerForTopProductDal = topCustomerForTopProductDal;
        }
        public List<TopCustomerForTopProduct> GetCustomerForTopProducts()
        {
            return _topCustomerForTopProductDal.GetList();
        }
    }
}

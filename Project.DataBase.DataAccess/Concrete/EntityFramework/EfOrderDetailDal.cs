using Project.Core.DataAccess.EntityFramework;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using SellingSites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, SellinSiteContext>, IOrderDetailDal
    {
        public List<ProductModels> GetOrdersWithDetails(string customerid ,int orderid)
        {
            using (SellinSiteContext context = new SellinSiteContext())
            {
                var result = from p in context.products
                             join od in context.orderdetails
                             on p.ProductId equals od.ProductId
                             join o in context.orders 
                             on od.OrderId equals o.OrderId
                             where(o.CustomerId == customerid )
                             where od.OrderId == orderid
                             select new ProductModels
                             {
                                 ProductName = p.ProductName,
                                 Quantity = od.Quantity,
                                 UnitPrice = p.UnitPrice
                             };

                return result.ToList();
            }
        }
    }
}

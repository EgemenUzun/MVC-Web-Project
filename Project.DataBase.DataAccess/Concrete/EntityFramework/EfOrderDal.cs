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
    public class EfOrderDal : EfEntityRepositoryBase<Order, SellinSiteContext>, IOrderDal
    {
        public List<OrderModel> GetOrdersWithDetails(string customerid)
        {
            using (SellinSiteContext context = new SellinSiteContext())
            {
                var result = from o in context.orders
                             join s in context.shippers
                             on o.ShipperId equals s.ShipperId
                             where (o.CustomerId == customerid)
                             where (o.IsProgress == true)
                             where(o.IsCanceled == false)
                             select new OrderModel
                             {
                                 OrderId = o.OrderId,
                                 CustomerId = o.CustomerId,
                                 OrderDate = o.OrderDate,
                                 RequiredDate = o.RequiredDate,
                                 CompanyName = s.CompanyName,
                                 Total = o.Total
                             };

                return result.ToList();
            }
        }
    }
}

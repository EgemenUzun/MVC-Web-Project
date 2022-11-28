using Microsoft.EntityFrameworkCore;
using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.DataAccess.Concrete.EntityFramework;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order order)
        {
            _orderDal.Add(order);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetList();
        }

        public Order GetByID(int orderId)
        {
            return _orderDal.Get(o => o.OrderId == orderId);
        }

        public void Order_Canceled(int orderId)
        { 
            using (SellinSiteContext context = new SellinSiteContext())
            {
                context.Database.ExecuteSqlRaw($"call is_canceled({orderId})");
            }
        }

        public void Order_Done(int orderId)
        {
            using (SellinSiteContext context = new SellinSiteContext())
            {
                context.Database.ExecuteSqlRaw($"call is_done({orderId})");
            }
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
    }
}

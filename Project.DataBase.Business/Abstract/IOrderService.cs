using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface IOrderService
    {
        void Add(Order order);
        void Update(Order order);
        Order GetByID(int orderId);
        List<Order> GetAll();
        void Order_Done(int orderId);
        void Order_Canceled(int orderId);
        List<OrderModel> GetOrdersWithDetails(string customerid);
    }
}

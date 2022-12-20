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
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
        }

        public List<OrderDetail> GetAll()
        {
            return _orderDetailDal.GetList();
        }

        public OrderDetail GetByID(int orderId)
        {
            return _orderDetailDal.Get(o => o.OrderId == orderId);
        }

        public List<ProductModels> GetOrdersWithDetails(string customerid, int orderid)
        {
            return _orderDetailDal.GetOrdersWithDetails(customerid, orderid);
        }
    }
}

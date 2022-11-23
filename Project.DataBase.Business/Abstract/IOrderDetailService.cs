using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAll();
        void Add(OrderDetail orderDetail);
        OrderDetail GetByID(int orderId);
    }
}

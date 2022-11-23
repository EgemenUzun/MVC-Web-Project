using Project.Core.DataAccess;
using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.DataAccess.Abstract
{
    public interface IOrderDetailDal: IEntityRepository<OrderDetail>
    {
        List<OrderModel> GetOrdersWithDetails(string customerid);
    }
}

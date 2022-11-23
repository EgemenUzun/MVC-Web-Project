using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface ICustomerService
    {
        Customer GetByID(string CustomerId);
        void Add(Customer customer);
    }
}

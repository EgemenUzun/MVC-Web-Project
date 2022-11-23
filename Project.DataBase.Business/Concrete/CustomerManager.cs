using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.DataAccess.Concrete.EntityFramework;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _cumtomerDal;
        public CustomerManager(ICustomerDal cumtomerDal)
        {
            _cumtomerDal = cumtomerDal;
        }

        public void Add(Customer customer)
        {
            _cumtomerDal.Add(customer);
        }

        public Customer GetByID(string CustomerId)
        {
            return _cumtomerDal.Get(c => c.CustomerId == CustomerId);
        }

    }
}

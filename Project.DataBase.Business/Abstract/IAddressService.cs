using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface IAddressService
    {
        void Add(Addresses addresses);
        void Update(Addresses addresses);
        void Delete(int addresId);
        public List<Addresses> GetByUser(string customerid);
    }
}

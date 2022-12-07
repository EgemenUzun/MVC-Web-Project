using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _address;
        public AddressManager(IAddressDal address)
        {
            _address = address;
        }

        public void Add(Addresses addresses)
        {
            _address.Add(addresses);
        }

        public void Delete(int addresId)
        {
            _address.Delete(new Addresses { AddressId = addresId });
        }

        public List<Addresses> GetByUser(string customerid)
        {
            return _address.GetList(ad => ad.CustomerId == customerid);
        }

        public void Update(Addresses addresses)
        {
            _address.Update(addresses);
        }
    }
}

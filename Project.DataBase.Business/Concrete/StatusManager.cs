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
    public class StatusManager : IStatusService
    {
        IStatusDal _statusDal;
        public StatusManager(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }

        public void Add(Status status)
        {
            _statusDal.Add(status);
        }

        public void Delete(int statusId)
        {
            _statusDal.Delete(new Status { StatusId = statusId });
        }

        public List<Status> GetStatuses()
        {
            return _statusDal.GetList();
        }

        public void Update(Status status)
        {
            _statusDal.Update(status);   
        }
    }
}

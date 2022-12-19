using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface IStatusService
    {
        void Update(Status status);
        void Add(Status status);
        void Delete(int statusId);
        List<Status> GetStatuses();
    }
}

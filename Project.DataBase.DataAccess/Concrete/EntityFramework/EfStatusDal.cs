using Project.Core.DataAccess.EntityFramework;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.DataAccess.Concrete.EntityFramework
{
    public class EfStatusDal: EfEntityRepositoryBase<Status, SellinSiteContext>, IStatusDal
    {
    }
}

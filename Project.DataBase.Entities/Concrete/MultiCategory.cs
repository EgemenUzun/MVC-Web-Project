using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.Concrete
{
    public class MultiCategory:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}

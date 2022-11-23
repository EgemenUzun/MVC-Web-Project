using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.Concrete
{
    public class Supplier : IEntity
    {
        public int SupplierId { get; set; }
        public int CutomerId { get; set; }
    }
}

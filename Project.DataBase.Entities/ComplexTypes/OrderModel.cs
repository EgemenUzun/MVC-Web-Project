using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.ComplexTypes
{
    public class  OrderModel:IEntity
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string CompanyName { get; set; }
        public string RequiredDate { get; set; }
        public string OrderDate { get; set; }
    }
}

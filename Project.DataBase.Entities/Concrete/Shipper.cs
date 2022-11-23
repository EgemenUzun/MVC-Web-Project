using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.Concrete
{
    public class Shipper : IEntity
    {
        public int ShipperId { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}

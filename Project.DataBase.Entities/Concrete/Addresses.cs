using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.Concrete
{
    public class Addresses:IEntity
    {
        [Required]
        public int AddressId { get; set; }
        [Required]
        public string AddressTitle { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string Country { get; set; }
        public string? CustomerId { get; set; }
    }
}

using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using NpgsqlTypes;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.Concrete
{
    public class Order: IEntity
    {

        public int OrderId { get; set; }
        [Required]
        public string  CustomerId { get; set; }
        [Required]
        public int ShipperId { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public int AddressId { get; set; }
        public decimal Total { get; set; }
        public bool? IsCanceled { get; set; }
        public bool? IsProgress { get; set; }
    }
}

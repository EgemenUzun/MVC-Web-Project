using Project.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SellingSites.Entities
{
    public class Category:IEntity
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}

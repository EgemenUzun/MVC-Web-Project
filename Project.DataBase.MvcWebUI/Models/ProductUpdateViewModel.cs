using Project.DataBase.Entities.Concrete;
using SellingSites.Entities;

namespace Project.DataBase.MvcWebUI.Models
{
    internal class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
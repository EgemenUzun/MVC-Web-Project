using Microsoft.Build.Framework;
using Project.DataBase.Entities.Concrete;
using SellingSites.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.DataBase.MvcWebUI.Models
{
    internal class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        [RegularExpression(@"^((?!-\\d).)*$")]
        public string UnitPrice { get; set; }
    }
}
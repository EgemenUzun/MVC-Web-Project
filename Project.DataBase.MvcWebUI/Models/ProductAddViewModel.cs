﻿using Project.DataBase.Entities.Concrete;
using SellingSites.Entities;

namespace Project.DataBase.MvcWebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get;  set; }
    }
}

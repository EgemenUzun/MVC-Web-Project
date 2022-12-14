using Microsoft.AspNetCore.Mvc;
using Project.DataBase.Business.Abstract;
using Project.DataBase.MvcWebUI.Models;
using Project.DataBase.MvcWebUI.TagHelpers;
using SellingSites.Entities;

namespace Project.DataBase.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ITopCustomerForTopProductService _topCustomerForTopProductService;
        public ProductController(IProductService porductService, ITopCustomerForTopProductService opCustomerForTopProductService)
        {
            _productService = porductService;
            _topCustomerForTopProductService = opCustomerForTopProductService;
        }

        public IActionResult Index(int page = 1, int category = 0 ,string search= null)
        {
            int pageSize = 12;
            var products = User.GetUserId() == null ? _productService.GetByCategory(category) :
                _productService.GetByLogin(User.GetUserId(), category);
            if (search!= null)
                products = User.GetUserId() == null ? _productService.searchProduct(search, category) :
                _productService.searchProduct(search, User.GetUserId(), category);
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize =pageSize,
                CurrentCategory = category
            };
            return View(model);
        }
        public IActionResult TopCustomerForTopProduct()
        {
            var model = new CustomerForTopProductsViewModel{
                topCustomerForTopProduct = _topCustomerForTopProductService.GetCustomerForTopProducts()
        };

            return View(model);
        }

    }
}

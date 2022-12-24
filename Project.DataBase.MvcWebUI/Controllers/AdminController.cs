using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.DataBase.Business.Abstract;
using Project.DataBase.Entities.Concrete;
using Project.DataBase.MvcWebUI.Models;
using Project.DataBase.MvcWebUI.TagHelpers;
using System.Security.Claims;

namespace Project.DataBase.MvcWebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        public AdminController(IProductService productService ,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var productListViewmodel = new ProductListViewModel
            {
                Products = _productService.GetByUser(User.GetUserId())
            };

            return View(productListViewmodel);
        }
        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Product product, string UnitPrice)
        {
            if(ModelState.IsValid)
            {
                product.UnitPrice = decimal.Parse(UnitPrice);
                product.SupplierId = this.User.GetUserId();
                _productService.Add(product);
                TempData.Add("message", "Product was successfully added");
            }
            
            return RedirectToAction("Add");
        }
        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetByID(productId),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Product product, string UnitPrice)
        {
            if (ModelState.IsValid)
            {
                product.UnitPrice = decimal.Parse(UnitPrice);
                product.SupplierId=this.User.GetUserId();
                product.UnitsOnOrder = _productService.GetByID(product.ProductId).UnitsOnOrder;
                _productService.Update(product);
                TempData.Add("message", "Product was successfully updated");
            }

            return RedirectToAction("Update");
        }
        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("message", "Product was successfully deleted");
            return RedirectToAction("Index");
        }
    }
}

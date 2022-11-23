using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Project.DataBase.Business.Abstract;
using Project.DataBase.Entities.Concrete;
using Project.DataBase.MvcWebUI.Models;
using Project.DataBase.MvcWebUI.Services;
using Project.DataBase.MvcWebUI.TagHelpers;
using System.Net;

namespace Project.DataBase.MvcWebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        ICartSessionService _cartSessionService;
        ICartService _cartService;
        IProductService _productService;
        IOrderService _oderService;
        IOrderDetailService _oderDetailService;
        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService, IOrderService oderService, IOrderDetailService oderDetailService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
            _oderService = oderService;
            _oderDetailService = oderDetailService;
        }
        public ActionResult AddToCArt(int productId)
        {
            var productToBeAdded = _productService.GetByID(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            foreach (CartLine item in cart.CartLines)
            {
                if (item.Product.SupplierId != User.GetUserId() &&item.Product.ProductId == productId && (item.Quantity <= item.Product.UnitsInStock - item.Product.UnitsOnOrder))
                {
                    _cartSessionService.SetCart(cart);
                    TempData.Add("message", String.Format("Your Product, {0}, was successfully added to the cart!", productToBeAdded.ProductName));                
                }
                else if(item.Product.ProductId == productId && (item.Quantity > item.Product.UnitsInStock - item.Product.UnitsOnOrder))
                    TempData.Add("message", String.Format("Your Product,{0} was faild to add because we dont have enough stocks", productToBeAdded.ProductName));
                else if(item.Product.SupplierId == User.GetUserId())
                    TempData.Add("message", String.Format("You shouldnt buy your product"));

            }
            return RedirectToAction("Index", "Product");
        }
        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);

        }
        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your Product was successfully removed from the cart!"));
            return RedirectToAction("List");
        }
        public IActionResult Complete()
        {

            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };

            return View();
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            var cart = _cartSessionService.GetCart();
            shippingDetails.ShipperId = 1;
            var modelOrder = new Order
            {
                CustomerId = User.GetUserId(),
                ShipperId = (int)shippingDetails.ShipperId,
                ShipAddress = shippingDetails.Address,
                ShipCity = shippingDetails.City,
                Total = cart.Total,
                OrderDate = DateTime.Now.ToString("yyyy-mm-dd"),
                RequiredDate = DateTime.Now.AddDays(15).ToString("yyyy-mm-dd"),
                IsProgress = true,
                IsCanceled = false
            };

            _oderService.Add(modelOrder);
            foreach (CartLine cartLine in cart.CartLines)
            {
                var modelOrderDetail = new OrderDetail
                {
                    OrderId = modelOrder.OrderId,
                    ProductId = cartLine.Product.ProductId,
                    Quantity = cartLine.Quantity,
                };
                _oderDetailService.Add(modelOrderDetail);
                var modelProduct = new Product
                {
                    ProductId = cartLine.Product.ProductId,
                    ProductName = cartLine.Product.ProductName,
                    SupplierId = cartLine.Product.SupplierId,
                    UnitsOnOrder = cartLine.Product.UnitsOnOrder + cartLine.Quantity,
                    CategoryId = cartLine.Product.CategoryId,
                    UnitPrice = cartLine.Product.UnitPrice,
                    UnitsInStock = cartLine.Product.UnitsInStock,
                };
                _productService.Update(modelProduct);
            }
        TempData.Add("message", String.Format("Thank you {0}, your oder is in process", shippingDetails.FirstName));
            return View();
    }
}

}

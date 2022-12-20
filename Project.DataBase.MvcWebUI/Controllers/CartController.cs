using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.Concrete;
using Project.DataBase.MvcWebUI.Models;
using Project.DataBase.MvcWebUI.Services;
using Project.DataBase.MvcWebUI.TagHelpers;
using System.Collections.Generic;
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
        IAddressService _addressService;
        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService, IOrderService oderService, IOrderDetailService oderDetailService ,IAddressService addressService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
            _oderService = oderService;
            _oderDetailService = oderDetailService;
            _addressService = addressService;
        }
        public ActionResult AddToCArt(int productId)
        {
            var productToBeAdded = _productService.GetByID(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            foreach (CartLine item in cart.CartLines)
            {
                if (item.Product.SupplierId != User.GetUserId() && item.Product.ProductId == productId && (item.Quantity <= item.Product.UnitsInStock - item.Product.UnitsOnOrder))
                {
                    _cartSessionService.SetCart(cart);
                    TempData.Clear();
                    TempData.Add("message", String.Format("Your Product, {0}, was successfully added to the cart!", productToBeAdded.ProductName));
                }
                else if (item.Product.ProductId == productId && (item.Quantity > item.Product.UnitsInStock - item.Product.UnitsOnOrder))
                {
                    TempData.Clear();
                    TempData.Add("message", String.Format("Your Product,{0} was faild to add because we dont have enough stocks", productToBeAdded.ProductName)); 
                }

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
            if (cart.CartLines.Count != 0)
                return View(cartListViewModel);
            TempData.Clear();
            TempData.Add("message", String.Format("Your cart is empty!"));
            return RedirectToAction("Index", "Product");

        }
        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Clear();
            TempData.Add("message", String.Format("Your Product was successfully removed from the cart!"));
            return RedirectToAction("List");
        }
        public IActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                addresses = _addressService.GetByUser(User.GetUserId())
            };
            if (shippingDetailsViewModel.addresses != null)
            {

                return View(shippingDetailsViewModel);
            }
                
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetailsViewModel shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                var shippingDetailsViewModel = new ShippingDetailsViewModel
                {
                    addresses = _addressService.GetByUser(User.GetUserId())
                };
                return View(shippingDetailsViewModel);

            }

            var cart = _cartSessionService.GetCart();
            var modelOrder = new Order
            {
                CustomerId = User.GetUserId(),
                ShipperId = 1,
                AddressId = shippingDetails.IAddressId,
                Total = cart.Total,
                OrderDate = DateTime.Now.ToString("yyyy-mm-dd"),
                RequiredDate = DateTime.Now.AddDays(15).ToString("yyyy-mm-dd"),
                StatusId = 1
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

            }
            return RedirectToAction("Index","Order");
    }
}

}

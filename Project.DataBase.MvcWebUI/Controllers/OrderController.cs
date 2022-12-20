using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using Project.DataBase.MvcWebUI.Models;
using Project.DataBase.MvcWebUI.TagHelpers;

namespace Project.DataBase.MvcWebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        IOrderService _orderService;
        IAddressService _addressService;
        public OrderController(IOrderService orderService, IAddressService addressService)
        {
            _orderService = orderService;
            _addressService = addressService;
        }

        public IActionResult Index()
        {

            var model = new OrderDetailModel
            {
                orderModels = _orderService.GetOrdersWithDetails(User.GetUserId())

            };
            return View(model);
        }
        public IActionResult NewAddress()
        {
            var model = new AddAddressViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult NewAddress(Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                addresses.CustomerId = User.GetUserId();
                _addressService.Add(addresses);
                TempData.Add("message", "Address Succesfuly added");
                return RedirectToAction("Complete", "Cart");
            }
            return View(addresses);
        }
        public IActionResult Done(int orderId)
        {
            _orderService.Order_Done(orderId);
            return RedirectToAction("Index", "Order");
        }
        public IActionResult Cancel(int orderId)
        {
            _orderService.Order_Canceled(orderId);
            return RedirectToAction("Index", "Order");
        }
    }
}

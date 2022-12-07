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
        IOrderDetailDal _orderDDal;
        IOrderDal _orderDal;
        IOrderService _orderService;
        IAddressDal _addressDal;
        public OrderController(IOrderDetailDal orderDDal, IOrderService orderService, IOrderDal orderDal, IAddressDal addressDal)
        {
            _orderDDal = orderDDal;
            _orderService = orderService;
            _orderDal = orderDal;
            _addressDal = addressDal;
        }

        public IActionResult Index()
        {

            var model = new OrderDetailModel
            {
                orderModels = _orderDal.GetOrdersWithDetails(User.GetUserId()),
               // productModels = _orderDDal.GetOrdersWithDetails(User.GetUserId(), 1),

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
                _addressDal.Add(addresses);
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

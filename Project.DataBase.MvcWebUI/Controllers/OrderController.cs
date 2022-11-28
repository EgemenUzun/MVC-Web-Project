using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.ComplexTypes;
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
        public OrderController(IOrderDetailDal orderDDal, IOrderService orderService, IOrderDal orderDal)
        {
            _orderDDal = orderDDal;
            _orderService = orderService;
            _orderDal = orderDal;
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

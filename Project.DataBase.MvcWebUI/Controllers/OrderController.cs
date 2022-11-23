using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.MvcWebUI.Models;
using Project.DataBase.MvcWebUI.TagHelpers;

namespace Project.DataBase.MvcWebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        IOrderDetailDal _orderDDal;
        public OrderController(IOrderDetailDal orderDDal)
        {
            _orderDDal = orderDDal;
        }
        
        public IActionResult Index()
        {
            var model = new OrderDetailModel
            {
                orderModels = _orderDDal.GetOrdersWithDetails(User.GetUserId())
            };
            return View(model);
        }
    }
}

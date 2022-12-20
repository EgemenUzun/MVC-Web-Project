using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.MvcWebUI.Models;

namespace Project.DataBase.MvcWebUI.ViewComponents
{
    public class ProductDetailViewComponent:ViewComponent
    {
        IOrderDetailService _orderDetailService;
        public ProductDetailViewComponent(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        public ViewViewComponentResult Invoke(string userid,int orderid)
        {
            var model = new OrderDetailModel
            {
                productModels = _orderDetailService.GetOrdersWithDetails(userid,orderid)
            };
            return View(model);
        }
    }
}

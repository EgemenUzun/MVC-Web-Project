using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.MvcWebUI.Models;

namespace Project.DataBase.MvcWebUI.ViewComponents
{
    public class ProductDetailViewComponent:ViewComponent
    {
        IOrderDetailDal _orderDDal;
        public ProductDetailViewComponent(IOrderDetailDal orderDDal)
        {
           _orderDDal = orderDDal;
        }
        public ViewViewComponentResult Invoke(string userid,int orderid)
        {
            var model = new OrderDetailModel
            {
                productModels = _orderDDal.GetOrdersWithDetails(userid,orderid)
            };
            return View(model);
        }
    }
}

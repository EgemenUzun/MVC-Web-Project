using Project.DataBase.Entities.ComplexTypes;

namespace Project.DataBase.MvcWebUI.Models
{
    public class OrderDetailModel
    {
        public List<OrderModel> orderModels { get; set; }
        public List<ProductModels> productModels { get;  set; }
    }
}

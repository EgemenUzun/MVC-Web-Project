using Project.DataBase.Entities.Concrete;

namespace Project.DataBase.MvcWebUI.Models
{
    public class ShippingDetailsViewModel
    {
        public int IAddressId { get; set; }
        public List<Addresses>? addresses { get; set; }
    }
}
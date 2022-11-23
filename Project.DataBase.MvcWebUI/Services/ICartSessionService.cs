using Project.DataBase.Entities.Concrete;

namespace Project.DataBase.MvcWebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}

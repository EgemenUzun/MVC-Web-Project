using Project.Core.Entities;

namespace Project.DataBase.Entities.Concrete
{

    public class Cart: IEntity
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }
        public decimal Total { get { return CartLines.Sum(c=>c.Product.UnitPrice*c.Quantity); } 
        }
    }
}

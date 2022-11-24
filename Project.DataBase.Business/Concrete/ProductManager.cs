using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.Concrete;
using SellingSites.Entities;

namespace Project.DataBase.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => (p.CategoryId == categoryId || categoryId == 0));
        }
        public List<Product> GetByLogin(string customerid,int? categoryId)
        {
            return _productDal.GetList(p => ( p.SupplierId !=customerid && (p.CategoryId == categoryId || categoryId == 0)));
        }
        public List<Product> GetByUser(string customerid)
        {
            return _productDal.GetList(p => (p.SupplierId == customerid));
        }
        public Product GetByID(int productId )
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

    }
}

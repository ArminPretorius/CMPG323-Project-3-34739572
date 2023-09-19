using Models;

namespace EcoPower_Logistics.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product entity);
        void UpdateProduct(Product entity);
        void DeleteProduct(Product entity);
    }
}

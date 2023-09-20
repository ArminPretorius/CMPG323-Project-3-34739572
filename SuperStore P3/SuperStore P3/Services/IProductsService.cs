using Models;

namespace EcoPower_Logistics.Services
{
    //Products interface that will be used by the products repository
    public interface IProductsService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product entity);
        void UpdateProduct(Product entity);
        void DeleteProduct(Product entity);
    }
}

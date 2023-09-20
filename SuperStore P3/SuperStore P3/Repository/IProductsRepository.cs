using Models;

namespace EcoPower_Logistics.Repository
{
    //Products interface that will be used by the products repository
    public interface IProductsRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product entity);
        void UpdateProduct(Product entity);
        void DeleteProduct(Product entity);
    }
}

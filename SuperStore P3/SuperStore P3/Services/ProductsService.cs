using EcoPower_Logistics.Repository;
using Models;

namespace EcoPower_Logistics.Services
{
    //Products service that will be used by the products controller
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productsRepository.GetAll().ToList();
        }

        public Product GetProductById(int id)
        {
            return _productsRepository.GetAll().FirstOrDefault(x => x.ProductId == id);
        }

        public void AddProduct(Product entity)
        {
            _productsRepository.Add(entity);
        }

        public void UpdateProduct(Product entity)
        {
            _productsRepository.Update(entity);
        }

        public void DeleteProduct(Product entity)
        {
            _productsRepository.Delete(entity);
        }
    }
}

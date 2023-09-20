using Data;
using EcoPower_Logistics.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models;

namespace EcoPower_Logistics.Repository
{
    //Products repository that will be used to interact with the database
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }

        public Product GetProductById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ProductId == id);
        }

        public void AddProduct(Product entity)
        {
            Add(entity);
        }

        public void UpdateProduct(Product entity)
        {
            Update(entity);
        }

        public void DeleteProduct(Product entity)
        {
            Delete(entity);
        }
    }
}

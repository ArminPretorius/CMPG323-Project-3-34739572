using System.Collections.Generic;

namespace EcoPower_Logistics.Repository
{
    //Generic repository interface that will be used by all repositories
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

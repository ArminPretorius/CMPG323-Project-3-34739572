using Data;
using EcoPower_Logistics.Data;
using System.Collections.Generic;
using System.Linq;

namespace EcoPower_Logistics.Repository
{
    //Generic repository class that will be used by all repositories
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //Declares the context that will be used by all repositories
        protected readonly SuperStoreContext _context = new SuperStoreContext();

        //Generic repository methods that will be used by all repositories
        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity should not be null");
            }
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity should not be null");
            }
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity should not be null");
            }
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

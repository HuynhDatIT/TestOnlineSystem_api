using Microsoft.EntityFrameworkCore;
using Mini_project_API.Data;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_project_API.Repository
{
    public class GenericRepositoryCRUD<T> : IGenericRepositoryCRUD<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        public GenericRepositoryCRUD(IElearningDbContext db)
        {
            _dbSet = db.Set<T>();
        }
        public virtual async Task<IList<T>> GetAllAsync()
        {
            var listItem = await _dbSet.ToListAsync();
           
            return listItem;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var itemT = await _dbSet.FindAsync(id); 
        
            return itemT;
        }
        public virtual async Task AddAsync(T obj)
        {
           await _dbSet.AddAsync(obj);
        }

        public virtual void Update(T obj)
        {
            _dbSet.Update(obj);
        }

        public virtual void Remove(T obj)
        {
            _dbSet.Remove(obj);
        }

        public virtual void RemoveRange(ICollection<T> objs)
        {
           _dbSet.RemoveRange(objs);
        }

        public virtual async Task AddRangeAsync(ICollection<T> objs)
        {
            await _dbSet.AddRangeAsync(objs);
        }
    }
}

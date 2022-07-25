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
        protected readonly IElearningDbContext _db;
        public GenericRepositoryCRUD(IElearningDbContext db)
        {
            _db = db;
        }
        public async Task<IList<T>> GetAllAsync()
        {
            var listItem = await _db.Set<T>().ToListAsync();
            
            return listItem;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var itemT = await _db.Set<T>().FindAsync(id); 
        
            return itemT;
        }
        public async Task AddAsync(T obj)
        {
           await _db.Set<T>().AddAsync(obj);
        }

        public void Update(T obj)
        {
            _db.Set<T>().Update(obj);
        }
    }
}

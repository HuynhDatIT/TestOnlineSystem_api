using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IRepository
{
    public interface IGenericRepositoryCRUD<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T obj);
        void Remove(T obj);
        void RemoveRange(ICollection<T> objs);
        Task AddRangeAsync(ICollection<T> objs);
        void Update(T obj);
    }
}

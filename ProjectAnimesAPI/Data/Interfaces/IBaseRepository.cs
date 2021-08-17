using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAnimesAPI.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T> Create(T obj);
        
        Task<T> Update(T obj, int id);
        
        Task<T> Delete(int id);
        
        Task<T> GetById(int id);
    }
}
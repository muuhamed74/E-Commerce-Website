using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;
using Store.Domain.Specification;

namespace Store.Domain.Services
{
    public interface IGenericRepository<T> where T : BaseModel
    {
     
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);

        Task<IEnumerable<T>> GetAllAsync();




        Task AddAsync(T item);

        Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);

        Task<T> GetByIdAsync(int id);

        Task<int> GetCountWithSpecAsync(ISpecification<T> spec);

        void UpdateAsync(T item);
        void DeleteAsync(T item);


        // Save
        Task SaveAsync();

    }
}

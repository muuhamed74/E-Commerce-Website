using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;
using Store.Domain.Services;
using Store.Domain.Specification;

namespace Store.Repo.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
       
        
        private readonly StoreContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(StoreContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec) 
        {
            return  SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
        }


        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }




        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }


        public async Task<int> GetCountWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public void UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
        }

        public void DeleteAsync(T item)
        {
            _context.Set<T>().Remove(item);
        }
    }
}

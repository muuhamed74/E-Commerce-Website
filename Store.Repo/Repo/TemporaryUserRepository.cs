using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;
using Store.Domain.Services;

namespace Store.Repo.Repo
{
    public class TemporaryUserRepository : ITemporaryUserRepository
    {
        private readonly StoreContext _context;

        public TemporaryUserRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<UserStoreTemporary> GetByEmailAsync(string email)
        {
            return await _context.UserStoreTemporary.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(UserStoreTemporary user)
        {
            await _context.UserStoreTemporary.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserStoreTemporary user)
        {
            _context.UserStoreTemporary.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserStoreTemporary user)
        {
            _context.UserStoreTemporary.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}

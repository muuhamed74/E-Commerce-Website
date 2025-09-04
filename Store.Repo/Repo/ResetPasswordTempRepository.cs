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
    public class ResetPasswordTempRepository : IResetPasswordTempRepository
    {
        private readonly StoreContext _context;

        public ResetPasswordTempRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<ResetPasswordTemp?> GetByEmailAsync(string email)
        {
            return await _context.ResetPasswordTemps.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AddAsync(ResetPasswordTemp entity)
        {
            await _context.ResetPasswordTemps.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ResetPasswordTemp entity)
        {
            _context.ResetPasswordTemps.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ResetPasswordTemp entity)
        {
            _context.ResetPasswordTemps.Remove(entity);
            await _context.SaveChangesAsync();
        }

        
       
    }
}

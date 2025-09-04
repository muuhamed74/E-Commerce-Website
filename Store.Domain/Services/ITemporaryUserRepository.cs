using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Domain.Services
{
    public interface ITemporaryUserRepository
    {
        Task<UserStoreTemporary> GetByEmailAsync(string email);
        Task AddAsync(UserStoreTemporary user);
        Task UpdateAsync(UserStoreTemporary user);
        Task DeleteAsync(UserStoreTemporary user);
    }
}

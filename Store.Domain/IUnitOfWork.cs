using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Services;

namespace Store.Domain
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity> Reposit<TEntity>() where TEntity : Models.BaseModel;
        Task<int> CompleteAsync();

    }
}

using MiniCarsales.Api.Models.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Api.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<int> AddAsync(TEntity entity);
        Task<int> DeleteAsync(string id);
    }
}

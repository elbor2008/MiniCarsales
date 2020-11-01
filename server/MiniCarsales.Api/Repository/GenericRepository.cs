using Microsoft.EntityFrameworkCore;
using MiniCarsales.Api.Data;
using MiniCarsales.Api.Models.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Api.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public GenericRepository(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            _vehicleDbContext.Set<TEntity>().Add(entity);
            
            return await _vehicleDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(string id)
        {
            var entity = await _vehicleDbContext.FindAsync<TEntity>(id);
            _vehicleDbContext.Set<TEntity>().Remove(entity);

            return await _vehicleDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _vehicleDbContext.Set<TEntity>().ToListAsync();
        }
    }
}

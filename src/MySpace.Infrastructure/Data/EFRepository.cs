using Microsoft.EntityFrameworkCore;
using MySpace.ApplicationCore.Entities;
using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.Infrastructure.Data
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        protected readonly MySpaceDbContext _dbContext;
        public EFRepository(MySpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}

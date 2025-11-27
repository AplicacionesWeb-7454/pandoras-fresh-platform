using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pandoraFr.API.Shared.Domain.Repositories;
using pandoraFr.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace pandoraFr.API.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> FindByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
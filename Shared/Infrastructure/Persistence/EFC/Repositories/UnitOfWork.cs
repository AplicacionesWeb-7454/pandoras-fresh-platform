using System.Threading.Tasks;
using pandoraFr.API.Shared.Domain.Repositories;
using pandoraFr.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace pandoraFr.API.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
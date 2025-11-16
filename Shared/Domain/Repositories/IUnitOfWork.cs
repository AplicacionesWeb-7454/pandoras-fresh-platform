using System.Threading.Tasks;

namespace pandoraFr.API.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
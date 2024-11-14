

namespace AuthServer.Repository.Abstracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}

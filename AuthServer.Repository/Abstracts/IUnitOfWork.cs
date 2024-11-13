

namespace AuthServer.Repository.Abstracts;

internal interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}

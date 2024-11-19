using AuthServer.Repository.Abstracts;
using AuthServer.Repository.Context;

namespace AuthServer.Repository.Concretes;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}

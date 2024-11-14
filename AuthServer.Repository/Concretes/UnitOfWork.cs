using AuthServer.Repository.Context;

namespace AuthServer.Repository.Concretes;

public class UnitOfWork(AppDbContext context)
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}

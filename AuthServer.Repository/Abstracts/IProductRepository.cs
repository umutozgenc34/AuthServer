
using AuthServer.Model.Entity;
using Core.Repository;

namespace AuthServer.Repository.Abstracts;

public interface IProductRepository : IGenericRepository<Product,int>
{
}



using AuthServer.Model.Entity;
using AuthServer.Repository.Abstracts;
using AuthServer.Repository.Context;
using Core.Repository;

namespace AuthServer.Repository.Concretes;

public class ProductRepository(AppDbContext context) : GenericRepository<AppDbContext,Product,int>(context),IProductRepository
{
}

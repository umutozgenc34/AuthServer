

using AuthServer.Model.Entity;
using AuthServer.Repository.Context;
using AuthServer.Service.Abstract;
using Core.Repository;

namespace AuthServer.Service.Concrete;

public class UserRefreshTokenService(AppDbContext context) : GenericRepository<AppDbContext, UserRefreshToken, string>(context), IUserRefreshTokenService
{

}
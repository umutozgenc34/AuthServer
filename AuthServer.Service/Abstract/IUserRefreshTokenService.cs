

using AuthServer.Model.Entity;
using Core.Repository;

namespace AuthServer.Service.Abstract;

public interface IUserRefreshTokenService : IGenericRepository<UserRefreshToken, string>
{
}

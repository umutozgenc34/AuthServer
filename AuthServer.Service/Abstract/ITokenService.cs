

using AuthServer.Model.Configuration;
using AuthServer.Model.Dtos;
using AuthServer.Model.Entity;

namespace AuthServer.Service.Abstract;

public interface ITokenService
{
    TokenDto CreateToken(UserApp user);
    ClientTokenDto CreateTokenByClient (Client client);
}

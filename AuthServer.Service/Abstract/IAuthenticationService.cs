

using AuthServer.Model.Dtos;
using Core.ReturnModels;

namespace AuthServer.Service.Abstract;

public interface IAuthenticationService
{
    Task<ReturnModel<TokenDto>> CreateTokenAsync(LoginDto loginDto);
    Task<ReturnModel<TokenDto>> CreateTokenyByRefreshToken(string refreshToken);
    Task<ReturnModel> RevokeRefreshToken(string refreshToken);
    Task<ReturnModel<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto);
}

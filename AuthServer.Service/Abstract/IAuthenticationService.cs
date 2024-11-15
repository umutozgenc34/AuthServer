

using AuthServer.Model.Dtos;
using Core.ReturnModels;

namespace AuthServer.Service.Abstract;

public interface IAuthenticationService
{
    Task<ReturnModel<TokenDto>> CreateTokenAsync(LoginDto loginDto);
    Task<ReturnModel<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
    Task<ReturnModel> RevokeRefreshToken(string refreshToken);
    ReturnModel<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
}

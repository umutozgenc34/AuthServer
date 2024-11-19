

using AuthServer.Model.Configuration;
using AuthServer.Model.Dtos;
using AuthServer.Model.Entity;
using AuthServer.Repository.Abstracts;
using AuthServer.Service.Abstract;
using Azure;
using Core.Repository;
using Core.ReturnModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace AuthServer.Service.Concrete;

public class AuthenticationService : IAuthenticationService
{

    private readonly List<Client> _clients;
    private readonly ITokenService _tokenService;
    private readonly UserManager<UserApp> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRefreshTokenService _userRefreshTokenService;

    public AuthenticationService(IOptions<List<Client>> optionsClient, ITokenService tokenService, UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IUserRefreshTokenService userRefreshTokenService)
    {
        _clients = optionsClient.Value;

        _tokenService = tokenService;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _userRefreshTokenService = userRefreshTokenService;
    }

    public async Task<ReturnModel<TokenDto>> CreateTokenAsync(LoginDto loginDto)
    {
        if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));

        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null) return ReturnModel<TokenDto>.Fail("Email veya  Password yanlış", HttpStatusCode.BadRequest);

        if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return ReturnModel<TokenDto>.Fail("Email veya Password yanlış", HttpStatusCode.BadRequest);
        }
        var token = _tokenService.CreateToken(user);

        var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

        if (userRefreshToken == null)
        {
            await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
        }
        else
        {
            userRefreshToken.Code = token.RefreshToken;
            userRefreshToken.Expiration = token.RefreshTokenExpiration;
        }

        await _unitOfWork.SaveChangesAsync();

        return ReturnModel<TokenDto>.Success(token, HttpStatusCode.OK);
    }

    public ReturnModel<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
    {
        var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);

        if (client == null)
        {
            return ReturnModel<ClientTokenDto>.Fail("ClientId veya ClientSecret bulunamadı",HttpStatusCode.NotFound);
        }

        var token = _tokenService.CreateTokenByClient(client);

        return ReturnModel<ClientTokenDto>.Success(token, HttpStatusCode.OK);
    }

    public async Task<ReturnModel<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
    {
        var existRefreshToken = await _userRefreshTokenService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

        if (existRefreshToken == null)
        {
            return ReturnModel<TokenDto>.Fail("Refresh token bulunamadı", HttpStatusCode.NotFound);
        }

        var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);

        if (user == null)
        {
            return ReturnModel<TokenDto>.Fail("User Id bulunamadı",HttpStatusCode.NotFound);
        }

        var tokenDto = _tokenService.CreateToken(user);

        existRefreshToken.Code = tokenDto.RefreshToken;
        existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

        await _unitOfWork.SaveChangesAsync();

        return ReturnModel<TokenDto>.Success(tokenDto, HttpStatusCode.OK);
    }

    public async Task<ReturnModel> RevokeRefreshToken(string refreshToken)
    {
        var existRefreshToken = await _userRefreshTokenService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
        if (existRefreshToken == null)
        {
            return ReturnModel.Fail("Refresh token bulunamadı", HttpStatusCode.NotFound);
        }

        _userRefreshTokenService.Delete(existRefreshToken);

        await _unitOfWork.SaveChangesAsync();

        return ReturnModel.Success(HttpStatusCode.OK);
    }
}

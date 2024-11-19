using AuthServer.Model.Dtos;
using AuthServer.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthenticationService authService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto) => Ok(await authService.CreateTokenAsync(loginDto));

        [HttpPost]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto) => Ok(authService.CreateTokenByClient(clientLoginDto));

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto) => Ok(await authService.RevokeRefreshToken(refreshTokenDto.Token));

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto) => Ok(await authService.CreateTokenByRefreshToken(refreshTokenDto.Token));

    }
}

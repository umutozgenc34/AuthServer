using AuthServer.Model.Dtos;
using AuthServer.Service.Abstract;
using AuthServer.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto) => Ok(await userService.CreateUserAsync(createUserDto));

    [HttpGet]
    public async Task<IActionResult> GetUser() => Ok(await userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
   
}

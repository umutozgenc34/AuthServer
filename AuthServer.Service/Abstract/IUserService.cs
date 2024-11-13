

using AuthServer.Model.Dtos;
using Core.ReturnModels;

namespace AuthServer.Service.Abstract;

public interface IUserService
{
    Task<ReturnModel<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
    Task<ReturnModel<UserAppDto>> GetUserByNameAsync(string userName);
}



using AuthServer.Model.Dtos;
using AuthServer.Model.Entity;
using AuthServer.Service.Abstract;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using Azure;
using Core.ReturnModels;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace AuthServer.Service.Concrete;

public class UserService : IUserService
{
    private readonly UserManager<UserApp> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<UserApp> userManager,IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<ReturnModel<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };

        var result = await _userManager.CreateAsync(user, createUserDto.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();

            return ReturnModel<UserAppDto>.Fail(errors, HttpStatusCode.BadRequest);
        }
        var userAsDto = _mapper.Map<UserAppDto>(user);
        return ReturnModel<UserAppDto>.Success(userAsDto, HttpStatusCode.OK);
    }

    public async Task<ReturnModel<UserAppDto>> GetUserByNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return ReturnModel<UserAppDto>.Fail("UserName bulunamadı", HttpStatusCode.NotFound);
        }
        var userAsDto = _mapper.Map<UserAppDto>(user);
        return ReturnModel<UserAppDto>.Success(userAsDto, HttpStatusCode.OK);
    }
}

using AutoMapper;
using BeeTy.Data.IRepostories;
using BeeTy.Data.Repostories;
using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
using BeeTy.Service.Extensions;
using BeeTy.Service.Helpers;
using BeeTy.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Services;

public class UserService : IUserService
{
    private readonly IGenericRepostory<User> genericRepostory = new GenericRepostory<User>();
    private readonly DbContext dbContext;

    private readonly IMapper mapper;
    public UserService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<Response<UserDto>> CreateAsync(UserCDto user)
    {
        var users = await this.genericRepostory.SelectAllAsync();
        bool anyEntityExists = users.Any(u => u.Email.Equals(user.Email) && u.UserName.Equals(user.UserName));
        if (anyEntityExists)
        {
            return new Response<UserDto>
            {
                Code = 405,
                Message = "User is already exist",
                Value = null
            };
        }

        var mappedUser = this.mapper.Map<User>(user);
        mappedUser.Password = user.Password.Encrypt();
        var resultLast = this.mapper.Map<UserDto>(mappedUser);
        var UserCreate = genericRepostory.InsertAsync(mappedUser);

        return new Response<UserDto>
        {
            Code = 200,
            Message = "Succes",
            Value = resultLast
        };
    }

    public async Task<Response<bool>> UpdateAsync(UserCDto user, long id)
    {
        var users = await this.genericRepostory.SelectAllAsync();
        var userForUpdate = users.Where(user=> user.Id == id).FirstOrDefault();
        if( userForUpdate is null)
        {
            return new Response<bool>
            {
                Code = 405,
                Message = "This place is empty",
                Value = false
            };
        }
        userForUpdate.UpdatedAt = DateTime.UtcNow;
        userForUpdate.FirstName = user.FirstName;
        userForUpdate.LastName = user.LastName;
        userForUpdate.Email = user.Email;
        userForUpdate.UserName = user.UserName;
        userForUpdate.Password = user.Password;
        userForUpdate.Age = user.Age;
        await genericRepostory.UpdateAsync(userForUpdate);
        return new Response<bool>
        {
            Code = 200,
            Message = "Succes",
            Value = true 
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var user = await this.genericRepostory.DeleteAsync(p=> p.Id == id);
        if (user)
        {
            return new Response<bool>
            {
                Code = 200,
                Message = "Succes",
                Value = true
            };
        }

        return new Response<bool>
        {
            Code = 404,
            Message = "Not found",
            Value = false
        };
    }

    public async ValueTask<Response<UserDto>> GetAsync(Predicate<UserCDto> predicate = null)
    {
        var users = await this.genericRepostory.SelectAllAsync();
        if (!users.Any())
        {
            return new Response<UserDto>
            {
                Code = 404,
                Message = "This place is empty",
                Value = null
            };
        }

        if (predicate is null)
            predicate = x => true;

        var mappedUser = this.mapper.Map<UserDto>(users);

        return new Response<UserDto>
        {
            Code = 200,
            Message = "Succes",
            Value = mappedUser
        };
    }

    public async ValueTask<Response<List<UserDto>>> GetAllAsync(string search = null)
    {
        var users = await this.genericRepostory.SelectAllAsync();
        var content = users.ToList();
        if (content.Any())
        {
            return new Response<List<UserDto>>()
            {
                Code = 404,
                Message = "This place is empty",
                Value = null
            };
        }

        var result = users.Where(user => user.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase));
        var mappedUsers = this.mapper.Map<List<UserDto>>(result);

        return new Response<List<UserDto>>()
        {
            Code = 200,
            Message = "Succes",
            Value = mappedUsers
        };
    }
}

using AutoMapper;
using BeeTy.Data.DbContexts;
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
    private readonly IUserRepostory repostory = new UserRepostory();

    private readonly IMapper mapper;
    private AppDbContext dbContext;

    public UserService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public UserService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Response<UserDto>> CreateAsync(UserCDto user)
    {
        var users = await this.repostory.SelectAllAsync();
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
        var UserCreate = repostory.InsertAsync(mappedUser);

        return new Response<UserDto>
        {
            Code = 200,
            Message = "Succes",
            Value = resultLast
        };
    }

    public async Task<Response<bool>> UpdateAsync(UserCDto user, int id)
    {
        var users = await this.repostory.SelectAllAsync();
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
        await repostory.UpdateAsync(userForUpdate);
        return new Response<bool>
        {
            Code = 200,
            Message = "Succes",
            Value = true 
        };
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var user = await this.repostory.DeleteAsync(id);
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

    public async ValueTask<Response<UserDto>> GetAsync(int id)
    {
        var users = await this.repostory.SelectAsync(id);
        if (users is null)
        {
            return new Response<UserDto>
            {
                Code = 404,
                Message = "This place is empty",
                Value = null
            };
        }


        var mappedUser = new UserDto
        {
            FirstName = users.FirstName,
            LastName = users.LastName,
            Email = users.Email,
            Password = users.Password,
            UserName = users.UserName,
            Phone = users.Phone
        };

        return new Response<UserDto>
        {
            Code = 200,
            Message = "Succes",
            Value = mappedUser = new UserDto{
                FirstName = users.FirstName,
                LastName = users.LastName,
                Email = users.Email,
                Password = users.Password,
                UserName = users.UserName,
                Phone = users.Phone
            }
        };
    }

    public async ValueTask<Response<List<UserDto>>> GetAllAsync(string search = null)
    {
        var users = await this.repostory.SelectAllAsync();
        var content = users.ToList();
        if (!content.Any())
        {
            return new Response<List<UserDto>>()
            {
                Code = 404,
                Message = "This place is empty",
                Value = null
            };
        }

        List<UserDto> userDtos = users.Select(u => new UserDto
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Password = u.Password,
            UserName = u.UserName,
            Age= u.Age,
            Phone = u.Phone
        }).ToList();


        return new Response<List<UserDto>>()
        {
            Code = 200,
            Message = "Succes",
            Value = userDtos
        };
    }
}

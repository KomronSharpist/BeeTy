﻿using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
using BeeTy.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Interfaces;

public interface IUserService
{
    Task<Response<UserDto>> CreateAsync (UserCDto user);
    Task<Response<bool>> UpdateAsync (UserCDto user, long id);
    Task<Response<bool>> DeleteAsync (long id);
    ValueTask<Response<UserDto>> GetAsync (Predicate<UserCDto> predicate = null);
    ValueTask<Response<List<UserDto>>> GetAllAsync(string search = null);
}

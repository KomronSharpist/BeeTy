﻿using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
using BeeTy.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Interfaces;

public interface IOrderService
{
    Task<Response<Order>> CreateAsync(Order order);
    Task<Response<bool>> UpdateAsync(Order order, int id);
    Task<Response<bool>> DeleteAsync(int id);
    ValueTask<Response<Order>> GetAsync(int id);
    ValueTask<Response<List<Order>>> GetAllAsync(string search = null);
}

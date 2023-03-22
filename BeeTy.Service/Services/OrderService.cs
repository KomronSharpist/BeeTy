using AutoMapper;
using BeeTy.Data.DbContexts;
using BeeTy.Data.IRepostories;
using BeeTy.Data.Repostories;
using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
using BeeTy.Service.Helpers;
using BeeTy.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepostory orderRepostory = new OrderRepostory();

    private readonly IMapper mapper;
    private AppDbContext dbContext;

    public OrderService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public OrderService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Response<Order>> CreateAsync(Order order)
    {
        var result = await this.orderRepostory.InsertAsync(order);
        return new Response<Order>
        {
            Code = 200,
            Message = "Succes",
            Value = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var order = (await this.orderRepostory.SelectAllAsync()).FirstOrDefault(p=> p.Id == id);
        if(order is null)
        {
            return new Response<bool>
            {
                Code = 404,
                Message = "Not Found",
                Value = false
            };
        }
        return new Response<bool>
        {
            Code = 200,
            Message = "Succes",
            Value = true
        };
    }

    public async ValueTask<Response<List<Order>>> GetAllAsync(string search = null)
    {
        var orders = await this.orderRepostory.SelectAllAsync();
        if (orders is null)
        {
            return new Response<List<Order>>
            {
                Code = 404,
                Message = "Not found",
                Value = null
            };
        }

        return new Response<List<Order>>
        {
            Code = 200,
            Message = "Succes",
            Value = orders
        };
    }

    public async ValueTask<Response<Order>> GetAsync(int id)
    {
        var orders = await this.orderRepostory.SelectAsync(id);
        if (orders is not null)
        {
            return new Response<Order>
            {
                Code = 404,
                Message = "Not found",
                Value = null
            };
        }

        var mappeOrder = this.mapper.Map<Order>(orders);


        return new Response<Order>
        {
            Code = 200,
            Message = "Succes",
            Value = mappeOrder
        };
    }

    public async Task<Response<bool>> UpdateAsync(Order order, int id)
    {
        var orders = await this.orderRepostory.SelectAllAsync();
        var orderForUpdate = orders.Where(w => w.Id == id).FirstOrDefault();
        if(orderForUpdate is not null)
        {
            orderForUpdate.UpdatedAt = DateTime.UtcNow;
            orderForUpdate.UserId = order.UserId;
            orderForUpdate.WorkerId = order.WorkerId;

            await orderRepostory.UpdateAsync(orderForUpdate);

            return new Response<bool>
            {
                Code = 200,
                Message = "Succes",
                Value = true
            };
        }
        return new Response<bool>
        {
            Code = 405,
            Message = "This place is empty",
            Value = false
        };
    }
}

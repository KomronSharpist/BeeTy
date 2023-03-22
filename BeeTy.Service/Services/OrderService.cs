using BeeTy.Domain.Entities;
using BeeTy.Service.Helpers;
using BeeTy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Services;

public class OrderService : IOrderService
{
    public Task<Response<Order>> CreateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Response<Order> GetAllAsync(Predicate<Order> predicate = null)
    {
        throw new NotImplementedException();
    }

    public Response<Order> GetAsync(Predicate<Order> predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> UpdateAsync(Order order, long id)
    {
        throw new NotImplementedException();
    }
}

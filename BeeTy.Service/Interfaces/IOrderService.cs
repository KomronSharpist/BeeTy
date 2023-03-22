using BeeTy.Domain.Entities;
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
    Task<Response<bool>> UpdateAsync(Order order, long id);
    Task<Response<bool>> DeleteAsync(long id);
    Response<Order> GetAsync(Predicate<Order> predicate = null);
    Response<Order> GetAllAsync(Predicate<Order> predicate = null);
}

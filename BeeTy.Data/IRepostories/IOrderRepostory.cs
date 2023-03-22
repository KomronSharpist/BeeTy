using BeeTy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Data.IRepostories;

public interface IOrderRepostory
{
    Task<Order> InsertAsync(Order model);
    Task<Order> UpdateAsync(Order model);
    Task<bool> DeleteAsync(int id);
    Task<Order> SelectAsync(int id);
    Task<List<Order>> SelectAllAsync();
}

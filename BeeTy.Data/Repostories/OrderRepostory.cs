using BeeTy.Data.DbContexts;
using BeeTy.Data.IRepostories;
using BeeTy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Data.Repostories
{
    internal class OrderRepostory : IOrderRepostory
    {
        private readonly AppDbContext dbContext;

        public OrderRepostory(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public OrderRepostory()
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var ModelToDelete = this.dbContext.Orders.ToList().FirstOrDefault(p => p.Id == id);
            if (ModelToDelete is null)
                return false;


            dbContext.Orders.RemoveRange(ModelToDelete);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Order> InsertAsync(Order order)
        {
            var InsertedOrder = await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return InsertedOrder.Entity;
        }

        public async Task<List<Order>> SelectAllAsync()
        {
            List<Order> entities = await dbContext.Orders.ToListAsync();

            return entities;
        }

        public async Task<Order> SelectAsync(int id)
        {
            return dbContext.Orders.ToList().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            var updatedOrder = this.dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync();

            return updatedOrder.Entity;
        }
    }
}

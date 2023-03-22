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
    public class UserRepostory : IUserRepostory
    {
        private readonly AppDbContext dbContext = new AppDbContext();
        private AppDbContext context;

        public UserRepostory()
        {
        }

        public UserRepostory(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ModelToDelete = this.dbContext.Users.ToList().FirstOrDefault(p => p.Id == id);
            if (ModelToDelete is null)
                return false;


            dbContext.Users.RemoveRange(ModelToDelete);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> InsertAsync(User model)
        {
            var InsertedModel = dbContext.Users.Add(model);
            await dbContext.SaveChangesAsync();
            return InsertedModel.Entity;
        }

        public async Task<List<User>> SelectAllAsync()
        {
            List<User> entities = await dbContext.Users.ToListAsync();

            return entities;
        }

        public async Task<User> SelectAsync(int id)
        {
            return dbContext.Users.ToList().FirstOrDefault(x => x.Id == id);
        }

        public async Task<User> UpdateAsync(User model)
        {
            var updatedModel = this.dbContext.Users.Update(model);
            await dbContext.SaveChangesAsync();

            return updatedModel.Entity;
        }
    }
}

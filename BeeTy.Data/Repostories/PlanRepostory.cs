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
    public class PlanRepostory : IPlanRespotory
    {
        private readonly AppDbContext dbContext;
        private AppDbContext appcontext;

        public PlanRepostory()
        {
        }

        public PlanRepostory(AppDbContext appcontext)
        {
            this.appcontext = appcontext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ModelToDelete = this.dbContext.Plans.ToList().FirstOrDefault(p => p.Id == id);
            if (ModelToDelete is null)
                return false;


            dbContext.Plans.RemoveRange(ModelToDelete);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Plan> InsertAsync(Plan plan)
        {
            var InsertedPlan = dbContext.Plans.Add(plan);
            await dbContext.SaveChangesAsync();
            return InsertedPlan.Entity;
        }

        public async Task<List<Plan>> SelectAllAsync()
        {
            List<Plan> entities = await dbContext.Plans.ToListAsync();

            return entities;
        }

        public async Task<Plan> SelectAsync(int id)
        {
            return dbContext.Plans.ToList().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Plan> UpdateAsync(Plan plan)
        {
            var updatedPlan = this.dbContext.Plans.Update(plan);
            await dbContext.SaveChangesAsync();

            return updatedPlan.Entity;
        }
    }
}

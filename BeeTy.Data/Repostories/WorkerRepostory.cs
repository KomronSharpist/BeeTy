using BeeTy.Data.DbContexts;
using BeeTy.Data.IRepostories;
using BeeTy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Data.Repostories;

public class WorkerRepostory : IWorkerRepostory
{
    private readonly AppDbContext dbContext = new AppDbContext();

    public WorkerRepostory()
    {
    }

    public WorkerRepostory(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ModelToDelete = this.dbContext.Workers.ToList().FirstOrDefault(p => p.Id == id);
        if (ModelToDelete is null)
            return false;


        dbContext.Workers.RemoveRange(ModelToDelete);
        await dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Worker> InsertAsync(Worker worker)
    {
        var InsertedWorker = dbContext.Workers.Add(worker);
        await dbContext.SaveChangesAsync();
        return InsertedWorker.Entity;
    }

    public async Task<List<Worker>> SelectAllAsync()
    {
        List<Worker> entities = await dbContext.Workers.ToListAsync();

        return entities;
    }

    public async Task<Worker> SelectAsync(int id)
    {
        return dbContext.Workers.ToList().FirstOrDefault(x => x.Id == id);
    }

    public async Task<Worker> UpdateAsync(Worker worker)
    {
        var updatedWorker = this.dbContext.Workers.Update(worker);
        await dbContext.SaveChangesAsync();

        return updatedWorker.Entity;
    }
}

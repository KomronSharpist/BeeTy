using BeeTy.Data.DbContexts;
using BeeTy.Data.IRepostories;
using BeeTy.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace BeeTy.Data.Repostories;

public class GenericRepostory<TEntity> : IGenericRepostory<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<TEntity> dbModel;

    public GenericRepostory()
    {
    }

    public GenericRepostory(AppDbContext context)
    {
        dbContext = context;
        dbModel = context.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(Predicate<TEntity> predicate = null)
    {
        if (predicate is null)
            predicate = x => true;

        
        var ModelToDelete = this.dbModel.ToList().FirstOrDefault(p => predicate(p));
        if (ModelToDelete is null)
            return false;


        dbModel.RemoveRange(ModelToDelete);
        await dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity model)
    {
        var InsertedModel = await this.dbModel.AddAsync(model);
        await dbContext.SaveChangesAsync();

        return InsertedModel.Entity;
    }

    public async Task<List<TEntity>> SelectAllAsync(Predicate<TEntity> predicate = null)
        => await this.dbModel.ToListAsync();

    public async Task<TEntity> SelectAsync(Predicate<TEntity> predicate = null)
    {
        if (predicate is null)
            predicate = x => true;

        return dbModel.ToList().FirstOrDefault(x => predicate(x));
    }

    public async Task<TEntity> UpdateAsync(TEntity model)
    {
        var updatedModel = this.dbModel.Update(model);
        await dbContext.SaveChangesAsync();

        return updatedModel.Entity;
    }
}

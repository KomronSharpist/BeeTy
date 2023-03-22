namespace BeeTy.Data.IRepostories
{
    public interface IGenericRepostory<TEntity>
    {
        Task<TEntity> InsertAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        Task<bool> DeleteAsync(Predicate<TEntity> predicate = null);
        Task<TEntity> SelectAsync(Predicate<TEntity> predicate = null);
        Task<List<TEntity>> SelectAllAsync(Predicate<TEntity> predicate = null);
    }
}

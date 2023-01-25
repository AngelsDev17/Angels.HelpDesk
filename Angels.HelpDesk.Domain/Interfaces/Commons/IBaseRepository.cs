namespace Angels.HelpDesk.Domain.Interfaces.Commons
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> FindAllAsync();
        Task<string> InsertOneAsync(T entity);
        Task<List<string>> InsertManyAsync(List<T> entities);
        Task DeleteOneAsync(string id);
    }
}

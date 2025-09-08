namespace IScore.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<bool> CreateAsync(T model);
        Task<bool> ModifyAsync(int id, T model);
        Task<bool> DeleteItemByKeyAsync(object primaryKey);
        Task<bool> DeleteItemAsync(T model);
        Task<IEnumerable<T>> GetListAsync();

        Task<IEnumerable<T>> GetFilteredListAsync();

    }
}

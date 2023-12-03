namespace Core.Common;

public interface IRepo<T> where T : IRoot
{
    public Task Create(T item);

    public Task<T> Get(int id);

    public Task Update(T item);
}
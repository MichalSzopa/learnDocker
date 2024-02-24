namespace Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task Add(T entity);
}
using System.Linq.Expressions;

namespace WebsOne.Api.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> FindAll();
        Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindOneByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task Update(T entity);
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebsOne.Api.Contracts;
using WebsOne.Api.Databases;

namespace WebsOne.Api.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly SqlServerContext _context;

        public RepositoryBase(SqlServerContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await Save();
        }

        public Task<List<T>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindOneByCondition(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await Save();
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using System.Linq.Expressions;
using Api.Data;
using Api.DTO;

namespace Api.Repositories.Generic;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> Query { get; }

    ApplicationDbContext Context { get; }
    T Save(T entity);
    T Update(T entity);
    void Delete(T entity);

    //Cannot do this anymore since keys can be different per table.
    //TEntity GetById(int id);

    //So you do this
    T Find(params object[] keys);

    public List<T> List(Expression<Func<T, bool>>  filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");
    int Count(Expression<Func<T, bool>> filter = null);

    public T Select(Expression<Func<T, bool>> predicate);

    public PagedItems<T> Paginate(Expression<Func<T, bool>> predicate, PagedOptions pagedFilter);

    IEnumerable<T> FindAll();

    PagedItems<T> PaginationQueryRepository<TResult>(PagedOptions pagedFilter, IQueryable<T> query);

    void DetachEntries();
}
using App.Rifas.Core.DataAccess.Context;
using App.Rifas.Core.Mapping.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query { get; }

        RifazDBContext Context { get; }
        T Salvar(T entity);
        T Update(T entity);
        void Apagar(T entity);

        //Cannot do this anymore since keys can be different per table.
        //TEntity GetById(int id);

        //So you do this
        T Find(params object[] keys);

        public List<T> Listar(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        int Count(Expression<Func<T, bool>> filter = null);

        public T Selecionar(Expression<Func<T, bool>> predicate);

        public PagedItems<T> ListarPaginado(Expression<Func<T, bool>> predicate, PagedOptions pagedFilter);

        IEnumerable<T> FindAll();


        PagedItems<T> PaginationQueryRepository<TResult>(PagedOptions pagedFilter, IQueryable<T> query);

        void DetachEntries();

    }
}

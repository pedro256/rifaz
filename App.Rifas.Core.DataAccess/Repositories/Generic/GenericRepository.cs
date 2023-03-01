using App.Rifas.Core.DataAccess.Context;
using App.Rifas.Core.Mapping.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public RifazDBContext Context { get; private set; }
        protected DbSet<T> Set => Context.Set<T>();

        public GenericRepository(RifazDBContext db_dbContext)
        {
            Context = db_dbContext;
        }

        public IQueryable<T> Query => Set;


        public T Find(params object[] keys)
        {
            return Set.Find(keys);
        }

        public IEnumerable<T> FindAll()
        {
            var teste = Set.AsNoTracking().ToList();
            return teste;
        }

        public T Salvar(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Add(entity);
            return entity;
        }

        public void Apagar(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Attach(entity);
            Set.Remove(entity);
        }


        public T Update(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Attach(entity);
            entry.State = EntityState.Modified;
            return entity;

        }

        public T Selecionar(Expression<Func<T, bool>> predicate)
        {
            return Context
                    .Set<T>() 
                    .AsNoTracking()
                    .FirstOrDefault(predicate);
        }

        public List<T> Listar(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = Context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query)
                    .AsNoTracking()
                    .ToList();
            }
            else
            {
                return query
                    .AsNoTracking()
                    .ToList();
            }
        }

        public int Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query
                .AsNoTracking()
                .Count();

        }

        public PagedItems<T> ListarPaginado(Expression<Func<T, bool>> predicate, PagedOptions pagedFilter)
        {
            if (string.IsNullOrEmpty(pagedFilter.Sort) && pagedFilter.SortManny == null)
            {
                var props = typeof(T)
                    .GetProperties()
                    .Where(prop =>
                        Attribute.IsDefined(prop,
                            typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));

                pagedFilter.Sort = props.First().Name;
            }

            PagedItems<T> paged = new PagedItems<T>();

            var query = Context
                .Set<T>()
                .AsNoTracking()
                .Where(predicate)
                .AsQueryable();

            paged.Total = query.Count();

            if (!string.IsNullOrEmpty(pagedFilter.Sort))
            {
                query = LinqExtension.OrderBy(query, pagedFilter.Sort, pagedFilter.Reverse);
            }
            else
            {
                if (pagedFilter.SortManny != null)
                {
                    var list = pagedFilter.SortManny.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == 0)
                        {
                            query = LinqExtension.OrderBy(query, list[i].Sort, list[i].Reverse);
                        }
                        else
                        {
                            query = LinqExtension.ThenBy(query, list[i].Sort, list[i].Reverse);
                        }
                    }
                }
            }

            var skip = (pagedFilter.Page.Value * pagedFilter.Size.Value) - pagedFilter.Size.Value;
            query = query.Skip(skip);
            query = query.Take(pagedFilter.Size.Value);

            paged.Items = query.ToList();
            return paged;
        }

        public PagedItems<T> PaginationQueryRepository<TResult>(PagedOptions pagedFilter, IQueryable<T> query)
        {
            if (string.IsNullOrEmpty(pagedFilter.Sort) && pagedFilter.SortManny == null)
            {
                var props = typeof(T)
                    .GetProperties()
                    .Where(prop =>
                        Attribute.IsDefined(prop,
                            typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));

                pagedFilter.Sort = props.First().Name;
            }

            PagedItems<T> paged = new PagedItems<T>();

            paged.Total = query.Count();

            if (!string.IsNullOrEmpty(pagedFilter.Sort))
            {
                query = LinqExtension.OrderBy(query, pagedFilter.Sort, pagedFilter.Reverse);
            }
            else
            {
                if (pagedFilter.SortManny != null)
                {
                    var list = pagedFilter.SortManny.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == 0)
                        {
                            query = LinqExtension.OrderBy(query, list[i].Sort, list[i].Reverse);
                        }
                        else
                        {
                            query = LinqExtension.ThenBy(query, list[i].Sort, list[i].Reverse);
                        }
                    }
                }
            }

            var skip = (pagedFilter.Page.Value * pagedFilter.Size.Value) - pagedFilter.Size.Value;
            query = query.Skip(skip);
            query = query.Take(pagedFilter.Size.Value);

            var resultadoBusca = query.AsNoTracking().ToList();

            paged.Items = resultadoBusca;

            return paged;
        }

        public void DetachEntries()
        {
            foreach (var entry in this.Context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }

    }

}


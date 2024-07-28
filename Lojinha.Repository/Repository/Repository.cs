using Lojinha.Domain.Entities;
using Lojinha.Domain.IRepository;
using Lojinha.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace Lojinha.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbContext Context { get; set; }
        protected DbSet<T> Query { get; set; }

        public Repository(LojinhaContext context)
        {
            this.Context = context;
            this.Query = Context.Set<T>();
        }

        // Create
        public T Criar(T entity)
        {
            Query.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public void CriarLista(List<T> entities)
        {
            foreach (var item in entities) Query.Add(item);
            Context.SaveChanges();
        }

        // Read
        public T ObterPorId(int id, params string[] includes)
        {
            if (includes == null || includes.Length == 0) return Query.AsNoTracking().FirstOrDefault(e => e.Id == id);
            var content = Query.AsQueryable();
            foreach (string param in includes) content = content.Include(param).AsNoTracking();
            return content.AsQueryable().FirstOrDefault(e => e.Id == id);
        }

        public T ObterPorExpressao(Expression<Func<T, bool>> expression)
        {
            return Query.AsNoTracking().FirstOrDefault(expression);
        }

        public IQueryable<T> ListarTodos(params string[] includes)
        {
            if (includes == null || includes.Length == 0) return Query.AsNoTracking();
            var content = Query.AsQueryable();
            foreach (string param in includes) content = content.Include(param);
            return content.AsQueryable<T>();
        }

        public IQueryable<T> ListarTodosPorExpressao(Expression<Func<T, bool>> expression)
        {
            return Query.Where(expression).AsNoTracking();
        }

        // Update
        public T Atualizar(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public bool AtualizarLista(List<T> entities)
        {
            Context.UpdateRange(entities);
            Context.SaveChanges();
            return true;
        }

        //Delete
        public bool Deletar(int id)
        {
            var entity = Query.FirstOrDefault(e => e.Id == id);
            if (entity == null) return false;
            Query.Remove(entity);
            Context.SaveChanges();
            return true;
        }

        // Auxiliares
        public async Task<IDbContextTransaction> CriarTransacao()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public async Task<IDbContextTransaction> CriarTransacao(IsolationLevel isolation)
        {
            return await Context.Database.BeginTransactionAsync(isolation);
        }
    }
}
using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace Lojinha.Domain.IRepository
{
    public interface IRepository<T> where T : Entity
    {
        // Create
        T Criar(T entity);
        void CriarLista(List<T> entities);

        // Read
        T ObterPorId(int id, params string[] includes);
        T ObterPorExpressao(Expression<Func<T, bool>> expression);
        IQueryable<T> ListarTodos(params string[] includes);
        IQueryable<T> ListarTodosPorExpressao(Expression<Func<T, bool>> expression);

        // Update
        T Atualizar(T entity);
        bool AtualizarLista(List<T> entities);

        // Delete
        bool Deletar(int id);

        // Auxiliares
        Task<IDbContextTransaction> CriarTransacao();
        Task<IDbContextTransaction> CriarTransacao(IsolationLevel isolation);
    }
}
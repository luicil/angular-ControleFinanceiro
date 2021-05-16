using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        IQueryable<TEntity> PegarTodos();
        Task<TEntity> PegarPeloID(int id);
        Task<TEntity> PegarPeloID(string id);
        Task Inserir(TEntity entity);
        Task Inserir(List<TEntity> entity);
        Task Atualizar(TEntity entity);
        Task Excluir(string id);
        Task Excluir(int id);

    }
}

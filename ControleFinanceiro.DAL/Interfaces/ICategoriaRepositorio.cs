using System;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface ICategoriaRepositorio : IRepositorioGenerico<Categoria>
    {
        new IQueryable<Categoria> PegarTodos();

        new Task<Categoria> PegarPeloID(int id);

        IQueryable<Categoria> FiltrarCategoria(string filtro);
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IFuncaoRepositorio : IRepositorioGenerico<Funcao>
    {

        Task AdicionarFuncao(Funcao funcao);

        Task AtualizarFuncao(Funcao funcao);

        IQueryable<Funcao> FiltrarFuncoes(string nomeFuncao);

    }
}

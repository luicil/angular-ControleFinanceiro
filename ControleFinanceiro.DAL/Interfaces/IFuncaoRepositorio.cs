using System;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IFuncaoRepositorio : IRepositorioGenerico<Funcao>
    {

        Task AdicionarFuncao(Funcao funcao);

        Task AtualizarFuncao(Funcao funcao);



    }
}

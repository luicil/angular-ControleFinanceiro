using System;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;
using System.Text;
using System.Collections.Generic;


namespace ControleFinanceiro.DAL.Interfaces
{
    public interface ICartaoRepositorio : IRepositorioGenerico<Cartao>
    {
        IQueryable<Cartao> PegarCartoesPeloUsuarioId(string usuarioId);

        IQueryable<Cartao> FiltrarCartoes(string numeroCartao);

        Task<int> PegarQuantidadeCartoesPeloUsuarioId(string usuarioId);
    }
}

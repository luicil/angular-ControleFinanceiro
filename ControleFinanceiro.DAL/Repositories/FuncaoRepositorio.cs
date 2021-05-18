using System;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.DAL.Repositories
{
    public class FuncaoRepositorio : RepositorioGenerico<Funcao>, IFuncaoRepositorio
    {

        private readonly Contexto _contexto;
        private readonly RoleManager<Funcao> _gerenciadorFuncoes;

        public FuncaoRepositorio(Contexto contexto, RoleManager<Funcao> gerenciadorFuncoes) : base(contexto) {
            _contexto = contexto;
            _gerenciadorFuncoes = gerenciadorFuncoes;
        }


        public async Task AdicionarFuncao(Funcao funcao)
        {
            try
            {
                await _gerenciadorFuncoes.CreateAsync(funcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AtualizarFuncao(Funcao funcao)
        {
            try
            {
                Funcao f = await PegarPeloID(funcao.Id);
                f.Name = funcao.Name;
                f.NormalizedName = funcao.NormalizedName;
                f.Descricao = funcao.Descricao;

                await _gerenciadorFuncoes.UpdateAsync(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

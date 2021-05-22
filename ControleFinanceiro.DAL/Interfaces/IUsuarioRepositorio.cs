using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;
using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario>
    {

        Task<int> PegarQuantidadeUsuariosRegistrados();

        Task<IdentityResult> CriarUsuario(Usuario usuario, string senha);

        Task InclurUsuarioFuncao(Usuario usuario, string funcao);

        Task LogarUsuario(Usuario usuario, bool lembrar);

        Task<Usuario> pegarPeloEmail(string email);

    }
}

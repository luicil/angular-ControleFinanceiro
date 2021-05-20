using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.DAL.Repositories
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {

        private readonly Contexto _contexto;
        private readonly UserManager<Usuario> _gerenciadorUsuarios;
        private readonly SignInManager<Usuario> _gerenciadorLogin;

        public UsuarioRepositorio(Contexto contexto, UserManager<Usuario> gerenciadorUsuarios, SignInManager<Usuario> gerenciadorLogin) : base(contexto)
        {
            _contexto = contexto;
            _gerenciadorUsuarios = gerenciadorUsuarios;
            _gerenciadorLogin = gerenciadorLogin;

        }

        public async Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            try
            {
                return await _gerenciadorUsuarios.CreateAsync(usuario, senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InclurUsuarioFuncao(Usuario usuario, string funcao)
        {
            try
            {
                await _gerenciadorUsuarios.AddToRoleAsync(usuario, funcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            try
            {
                await _gerenciadorLogin.SignInAsync(usuario, lembrar);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> PegarQuantidadeUsuariosRegistrados()
        {
            try
            {
                return await _contexto.Usuarios.CountAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using ControleFinanceiro.DAL.Interfaces;
using System.IO;
using ControleFinanceiro.API.ViewModels;
using Microsoft.AspNetCore.Identity;
using ControleFinanceiro.API.Services;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string id)
        {
            var usuario = await _usuarioRepositorio.PegarPeloID(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost("SalvarFoto")]
        public async Task<ActionResult> SalvarFoto()
        {
            var foto = Request.Form.Files[0];
            byte[] b;
            using (var openReadStream = foto.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await openReadStream.CopyToAsync(memoryStream);
                    b = memoryStream.ToArray();

                }
            }
            return Ok(new
            {
                foto = b
            });
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<ActionResult> RegistrarUsuario(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult usuarioCriado;
                string funcaoUsuario;

                Usuario usuario = new Usuario
                {
                    UserName = model.NomeUsuario,
                    Email = model.Email,
                    CPF = model.CPF,
                    Foto = model.Foto,
                    PasswordHash = model.Senha,
                    Profissao = model.Profissao
                };
                if(await _usuarioRepositorio.PegarQuantidadeUsuariosRegistrados() > 0)
                {
                    funcaoUsuario = "Usuario";
                } else
                {
                    funcaoUsuario = "Administrador";
                }

                usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);

                if (usuarioCriado.Succeeded)
                {
                    await _usuarioRepositorio.InclurUsuarioFuncao(usuario, funcaoUsuario);
                    var token = TokenService.GerarToken(usuario, funcaoUsuario);
                    await _usuarioRepositorio.LogarUsuario(usuario, false);
                    return Ok(new
                    {
                        emailUsuarioLogado = usuario.Email,
                        usuarioID = usuario.Id,
                        tokenUsuarioLogado = token
                    });
                } else
                {
                    return BadRequest(model);
                }
            }
            return BadRequest(model);
        }

        [HttpPost("LogarUsuario")]
        public async Task<ActionResult> LogarUsuario(LoginViewModel model)
        {
            if(model == null)
                return NotFound("Usuário e/ou senha incorretos");

            Usuario usuario = await _usuarioRepositorio.pegarPeloEmail(model.Email);

            if(usuario != null)
            {
                PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();
                if(passwordHasher.VerifyHashedPassword(usuario,usuario.PasswordHash,model.Senha) != PasswordVerificationResult.Failed)
                {
                    var funcoesUsuario = await _usuarioRepositorio.PegarFuncoesUsuario(usuario);
                    
                    var token = TokenService.GerarToken(usuario, funcoesUsuario.First());
                    await _usuarioRepositorio.LogarUsuario(usuario, false);
                    return Ok(new
                    {
                        emailUsuarioLogado = usuario.Email,
                        usuarioId = usuario.Id,
                        tokenUsuarioLogado = token
                    });
                }
                return NotFound("Usuário e/ou senha incorretos");
            }
            return NotFound("Usuário e/ou senha incorretos");
        }

    }
}

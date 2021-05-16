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

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
     
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        //public CategoriasController(Contexto context)
        public CategoriasController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _categoriaRepositorio.PegarTodos().ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _categoriaRepositorio.PegarPeloID(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaID)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _categoriaRepositorio.Atualizar(categoria);
                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} atualizada com sucesso !"
                });
            }
            return BadRequest(ModelState);

        }

        // POST: api/Categorias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {

            if (ModelState.IsValid)
            {

                await _categoriaRepositorio.Inserir(categoria);

                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} cadastrada com sucesso !"
                });

            }

            return BadRequest(ModelState);

        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {

            var categoria = await _categoriaRepositorio.PegarPeloID(id);

            if(categoria == null)
            {
                return NotFound();
            }
           await _categoriaRepositorio.Excluir(id);


            return Ok(new
            {
                mensagem = $"Categoria {categoria.Nome} cadastrada com sucesso !"
            });

        }

    }
}

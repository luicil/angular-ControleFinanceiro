using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.DAL.Repositories
{
    public class CategoriaRepositorio : IRepositorioGenerico<Categoria>,ICategoriaRepositorio
    {
        private readonly Contexto _contexto;

        public CategoriaRepositorio(Contexto contexto) : base()
        {
            _contexto = contexto;
        }

        public IQueryable<Categoria> PegarTodos()
        {
            try
            {
                return _contexto.Categorias.Include(c => c.Tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Categoria> PegarPeloID(int id)
        {
            try
            {
                var entity = await _contexto.Categorias.Include(c => c.Tipo).FirstOrDefaultAsync(c => c.CategoriaID == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

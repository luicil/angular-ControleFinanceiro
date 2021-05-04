using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.CPF).IsRequired().HasMaxLength(20);
            builder.HasIndex(i => i.CPF).IsUnique();
            builder.Property(t => t.Profissao).IsRequired().HasMaxLength(30);
            builder.HasMany(h => h.Cartoes).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Despesas).WithOne(c => c.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Ganhos).WithOne(c => c.Usuario).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Usuarios");


        }
    }
}

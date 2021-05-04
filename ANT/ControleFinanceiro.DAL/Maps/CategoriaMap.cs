using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ControleFinanceiro.BLL.Models;

namespace ControleFinanceiro.DAL.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {

        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(t => t.CategoriaID);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Icone).IsRequired().HasMaxLength(15);
            builder.HasOne(c => c.Tipo).WithMany(c => c.Categorias).HasForeignKey(f => f.TipoID).IsRequired();
            builder.HasMany(c => c.Ganhos).WithOne(c => c.Categoria);
            builder.HasMany(c => c.Despesas).WithOne(c => c.Categoria);

            builder.ToTable("Categorias");

        }
    }
}

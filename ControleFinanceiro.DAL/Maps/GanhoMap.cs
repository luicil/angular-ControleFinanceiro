using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Maps
{
    public class GanhoMap : IEntityTypeConfiguration<Ganho>
    {

        public void Configure(EntityTypeBuilder<Ganho> builder)
        {
            builder.HasKey(k => k.GanhoID);
            builder.Property(t => t.Descricao).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Valor).IsRequired();
            builder.Property(t => t.Dia).IsRequired();
            builder.Property(t => t.Ano).IsRequired();
            builder.HasOne(c => c.Categoria).WithMany(c => c.Ganhos).HasForeignKey(c => c.CategoriaID).IsRequired();
            builder.HasOne(c => c.Mes).WithMany(c => c.Ganhos).HasForeignKey(c => c.MesID).IsRequired();
            builder.HasOne(c => c.Usuario).WithMany(c => c.Ganhos).HasForeignKey(c => c.UsuarioID).IsRequired();

            builder.ToTable("Ganhos");

        }
    }
}

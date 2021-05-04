using System;
using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Maps
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(k => k.DespesaID);
            builder.Property(t => t.Descricao).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Valor).IsRequired();
            builder.Property(t => t.Dia).IsRequired();
            builder.Property(t => t.Ano).IsRequired();
            builder.HasOne(c => c.Cartao).WithMany(c => c.Despesas).HasForeignKey(c => c.DespesaID).IsRequired();
            builder.HasOne(c => c.Categoria).WithMany(c => c.Despesas).HasForeignKey(c => c.CategoriaID).IsRequired();
            builder.HasOne(c => c.Mes).WithMany(c => c.Despesas).HasForeignKey(c => c.MesID).IsRequired();
            builder.HasOne(c => c.Usuario).WithMany(c => c.Despesas).HasForeignKey(c => c.UsuarioID).IsRequired();

            builder.ToTable("Despesas");
        }
    }
}


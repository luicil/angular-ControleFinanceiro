using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Maps
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(k => k.CartaoID);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(50);
            builder.HasIndex(i => i.Nome).IsUnique();
            builder.Property(t => t.Bandeira).IsRequired().HasMaxLength(15);
            builder.Property(t => t.Numero).IsRequired().HasMaxLength(20);
            builder.HasIndex(i => i.Numero).IsUnique();
            builder.Property(t => t.Limite).IsRequired();

            builder.HasOne(c => c.Usuario).WithMany(c => c.Cartoes).HasForeignKey(c => c.UsuarioID).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Despesas).WithOne(c => c.Cartao);

            builder.ToTable("Cartoes");
        }
    }

}

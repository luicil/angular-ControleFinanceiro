using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Maps
{
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(t => t.TipoID);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(50);

            builder.HasMany(t => t.Categorias).WithOne(t => t.Tipo);

            builder.HasData(
                new Tipo
                {
                    TipoID = 1,
                    Nome = "Despesa"
                },
                new Tipo
                {
                    TipoID = 2,
                    Nome = "Ganho"
                }
            );

            builder.ToTable("Tipos");
        }
    }
}

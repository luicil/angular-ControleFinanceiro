using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Maps
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {

        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Descricao).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Descricao = "Administrador do sistema",
                    NormalizedName = "ADMINISTRADOR",
                    Name = "Administrador"

                },
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Descricao = "Usuario",
                    NormalizedName = "USUARIO",
                    Name = "Usuário do sistema"
                }
            );

            builder.ToTable("Funcoes");
        }
    }
}

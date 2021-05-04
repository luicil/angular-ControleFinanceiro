using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Maps
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.HasKey(k => k.MesID);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(20);
            builder.HasIndex(i => i.Nome).IsUnique();
            builder.HasMany(c => c.Despesas).WithOne(c => c.Mes);
            builder.HasMany(c => c.Ganhos).WithOne(c => c.Mes);

            builder.HasData(
                new Mes
                {
                    MesID = 1,
                    Nome = "Janeiro"
                },
                new Mes
                {
                    MesID = 2,
                    Nome = "Fevereiro"
                },
                new Mes
                {
                    MesID = 3,
                    Nome = "Março"
                },
                new Mes
                {
                    MesID = 4,
                    Nome = "Abril"
                },
                new Mes
                {
                    MesID = 5,
                    Nome = "Maio"
                },
                new Mes
                {
                    MesID = 6,
                    Nome = "Junho"
                },
                new Mes
                {
                    MesID = 7,
                    Nome = "Julho"
                },
                new Mes
                {
                    MesID = 8,
                    Nome = "Agosto"
                },
                new Mes
                {
                    MesID = 9,
                    Nome = "Setembro"
                },
                new Mes
                {
                    MesID = 10,
                    Nome = "Outubro"
                },
                new Mes
                {
                    MesID = 11,
                    Nome = "Novembro"
                },
                new Mes
                {
                    MesID = 12,
                    Nome = "Dezembro"
                }
            );


            builder.ToTable("Meses");
        }
    }
}

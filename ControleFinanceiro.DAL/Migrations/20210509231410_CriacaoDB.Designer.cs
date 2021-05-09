﻿// <auto-generated />
using System;
using ControleFinanceiro.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleFinanceiro.DAL.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210509231410_CriacaoDB")]
    partial class CriacaoDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Cartao", b =>
                {
                    b.Property<int>("CartaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bandeira")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<double>("Limite")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UsuarioID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CartaoID");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("Numero")
                        .IsUnique();

                    b.HasIndex("UsuarioID");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TipoID")
                        .HasColumnType("int");

                    b.HasKey("CategoriaID");

                    b.HasIndex("TipoID");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Despesa", b =>
                {
                    b.Property<int>("DespesaID")
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("CartaoID")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("MesID")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("DespesaID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("MesID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Funcao", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Funcoes");

                    b.HasData(
                        new
                        {
                            Id = "d8d61117-2f06-41ba-81ed-a75b910042f1",
                            ConcurrencyStamp = "964dd7c2-8de5-4076-9c1e-9d6e311029b6",
                            Descricao = "Administrador do sistema",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "edffbee6-eeaa-4a7b-96b0-c69eb9d88253",
                            ConcurrencyStamp = "62a704bb-168c-4a54-967d-28b3329b4d10",
                            Descricao = "Usuario",
                            Name = "Usuário do sistema",
                            NormalizedName = "USUARIO"
                        });
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Ganho", b =>
                {
                    b.Property<int>("GanhoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("MesID")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("GanhoID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("MesID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Ganhos");
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Mes", b =>
                {
                    b.Property<int>("MesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("MesID");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Meses");

                    b.HasData(
                        new
                        {
                            MesID = 1,
                            Nome = "Janeiro"
                        },
                        new
                        {
                            MesID = 2,
                            Nome = "Fevereiro"
                        },
                        new
                        {
                            MesID = 3,
                            Nome = "Março"
                        },
                        new
                        {
                            MesID = 4,
                            Nome = "Abril"
                        },
                        new
                        {
                            MesID = 5,
                            Nome = "Maio"
                        },
                        new
                        {
                            MesID = 6,
                            Nome = "Junho"
                        },
                        new
                        {
                            MesID = 7,
                            Nome = "Julho"
                        },
                        new
                        {
                            MesID = 8,
                            Nome = "Agosto"
                        },
                        new
                        {
                            MesID = 9,
                            Nome = "Setembro"
                        },
                        new
                        {
                            MesID = 10,
                            Nome = "Outubro"
                        },
                        new
                        {
                            MesID = 11,
                            Nome = "Novembro"
                        },
                        new
                        {
                            MesID = 12,
                            Nome = "Dezembro"
                        });
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Tipo", b =>
                {
                    b.Property<int>("TipoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TipoID");

                    b.ToTable("Tipos");

                    b.HasData(
                        new
                        {
                            TipoID = 1,
                            Nome = "Despesa"
                        },
                        new
                        {
                            TipoID = 2,
                            Nome = "Ganho"
                        });
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Cartao", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Usuario", "Usuario")
                        .WithMany("Cartoes")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Categoria", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Tipo", "Tipo")
                        .WithMany("Categorias")
                        .HasForeignKey("TipoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Despesa", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Categoria", "Categoria")
                        .WithMany("Despesas")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleFinanceiro.BLL.Models.Cartao", "Cartao")
                        .WithMany("Despesas")
                        .HasForeignKey("DespesaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleFinanceiro.BLL.Models.Mes", "Mes")
                        .WithMany("Despesas")
                        .HasForeignKey("MesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleFinanceiro.BLL.Models.Usuario", "Usuario")
                        .WithMany("Despesas")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ControleFinanceiro.BLL.Models.Ganho", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Categoria", "Categoria")
                        .WithMany("Ganhos")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleFinanceiro.BLL.Models.Mes", "Mes")
                        .WithMany("Ganhos")
                        .HasForeignKey("MesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleFinanceiro.BLL.Models.Usuario", "Usuario")
                        .WithMany("Ganhos")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Funcao", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Funcao", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleFinanceiro.BLL.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ControleFinanceiro.BLL.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

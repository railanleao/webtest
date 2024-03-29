﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webtest.Connection;

#nullable disable

namespace webtest.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20220201194400_mercado")]
    partial class mercado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webtest.Objects.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("CategoriaId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Nome");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("webtest.Objects.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ClienteId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Nome");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("SobreNome");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("webtest.Objects.ItenVenda", b =>
                {
                    b.Property<int>("ItenVendaId")
                        .HasColumnType("integer")
                        .HasColumnName("ItemVendaId");

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<int>("NumVendaId")
                        .HasColumnType("integer");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.Property<string>("ProdutoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.HasKey("ItenVendaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ItenVenda");
                });

            modelBuilder.Entity("webtest.Objects.Movimentacao", b =>
                {
                    b.Property<int>("MovimentacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("MovimentaçõesId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MovimentacaoId"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Data/Hora");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("Descrição");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.HasKey("MovimentacaoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Movimentações", (string)null);
                });

            modelBuilder.Entity("webtest.Objects.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("ProdutoId");

                    b.Property<int>("CategoriaId")
                        .HasMaxLength(100)
                        .HasColumnType("integer")
                        .HasColumnName("Categorias");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("Descrição");

                    b.Property<int>("ItenVendaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Nome");

                    b.Property<int>("NumVendaId")
                        .HasMaxLength(500)
                        .HasColumnType("integer")
                        .HasColumnName("Movimentações");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision")
                        .HasColumnName("Preços");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer")
                        .HasColumnName("Quantidade");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ItenVendaId")
                        .IsUnique();

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("webtest.Objects.Venda", b =>
                {
                    b.Property<int>("NumVendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("NumVendaId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NumVendaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Data/Hora");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.HasKey("NumVendaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Vendas", (string)null);
                });

            modelBuilder.Entity("webtest.Objects.ItenVenda", b =>
                {
                    b.HasOne("webtest.Objects.Cliente", "Cliente")
                        .WithMany("ItenVenda")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webtest.Objects.Venda", "Venda")
                        .WithMany("ItenVenda")
                        .HasForeignKey("ItenVendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("webtest.Objects.Movimentacao", b =>
                {
                    b.HasOne("webtest.Objects.Produto", "Produto")
                        .WithMany("Movimentacao")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("webtest.Objects.Produto", b =>
                {
                    b.HasOne("webtest.Objects.Categoria", "Categoria")
                        .WithMany("Produto")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webtest.Objects.ItenVenda", null)
                        .WithOne("Produto")
                        .HasForeignKey("webtest.Objects.Produto", "ItenVendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webtest.Objects.ItenVenda", "ItenVenda")
                        .WithMany("Produtos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webtest.Objects.Venda", "Venda")
                        .WithMany("Produtos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("ItenVenda");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("webtest.Objects.Venda", b =>
                {
                    b.HasOne("webtest.Objects.Cliente", "Cliente")
                        .WithMany("Venda")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webtest.Objects.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("webtest.Objects.Categoria", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("webtest.Objects.Cliente", b =>
                {
                    b.Navigation("ItenVenda");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("webtest.Objects.ItenVenda", b =>
                {
                    b.Navigation("Produto")
                        .IsRequired();

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("webtest.Objects.Produto", b =>
                {
                    b.Navigation("Movimentacao");
                });

            modelBuilder.Entity("webtest.Objects.Venda", b =>
                {
                    b.Navigation("ItenVenda");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using academiadospeixinhoscloud.Data;

#nullable disable

namespace academiadospeixinhoscloud.Migrations
{
    [DbContext(typeof(academiadospeixinhoscloudContext))]
    [Migration("20240320134416_fix_db")]
    partial class fix_db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AtividadeCrianca", b =>
                {
                    b.Property<int>("AtividadesId")
                        .HasColumnType("int");

                    b.Property<int>("CriancasId")
                        .HasColumnType("int");

                    b.HasKey("AtividadesId", "CriancasId");

                    b.HasIndex("CriancasId");

                    b.ToTable("AtividadeCrianca");
                });

            modelBuilder.Entity("CriancaPai", b =>
                {
                    b.Property<int>("CriancasId")
                        .HasColumnType("int");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("CriancasId", "PaisId");

                    b.HasIndex("PaisId");

                    b.ToTable("CriancaPai");
                });

            modelBuilder.Entity("CriancaSubscricao", b =>
                {
                    b.Property<int>("CriancasId")
                        .HasColumnType("int");

                    b.Property<int>("SubscricaoesId")
                        .HasColumnType("int");

                    b.HasKey("CriancasId", "SubscricaoesId");

                    b.HasIndex("SubscricaoesId");

                    b.ToTable("CriancaSubscricao");
                });

            modelBuilder.Entity("SalaSubscricao", b =>
                {
                    b.Property<int>("SalasId")
                        .HasColumnType("int");

                    b.Property<int>("SubscricoesId")
                        .HasColumnType("int");

                    b.HasKey("SalasId", "SubscricoesId");

                    b.HasIndex("SubscricoesId");

                    b.ToTable("SalaSubscricao");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Auxiliar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.Property<string>("Professor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Valida")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Atividade");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Crianca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apolice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Autorizados")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Doencas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoradaFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NBI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesAtividades")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesPais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesSubscricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroUtente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuantidadeAgregado")
                        .HasColumnType("int");

                    b.Property<string>("Seguradora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeguroSaude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidadeBI")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Crianca");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Ementa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesSalas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Valida")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Ementa");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesSalas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.Property<string>("Professor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Pai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoradaFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NBI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesCriancas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroUtente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidadeBI")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pai");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CriancaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CriancaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Auxiliar1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Auxiliar2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Auxiliar3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Educadora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmentaId")
                        .HasColumnType("int");

                    b.Property<int?>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesSubscricoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VagasPreenchidas")
                        .HasColumnType("int");

                    b.Property<int>("VagasTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmentaId");

                    b.HasIndex("EventoId");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Subscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesCriancas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomesSalas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.Property<bool>("Valida")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subscricao");
                });

            modelBuilder.Entity("AtividadeCrianca", b =>
                {
                    b.HasOne("academiadospeixinhoscloud.Models.Atividade", null)
                        .WithMany()
                        .HasForeignKey("AtividadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("academiadospeixinhoscloud.Models.Crianca", null)
                        .WithMany()
                        .HasForeignKey("CriancasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CriancaPai", b =>
                {
                    b.HasOne("academiadospeixinhoscloud.Models.Crianca", null)
                        .WithMany()
                        .HasForeignKey("CriancasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("academiadospeixinhoscloud.Models.Pai", null)
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CriancaSubscricao", b =>
                {
                    b.HasOne("academiadospeixinhoscloud.Models.Crianca", null)
                        .WithMany()
                        .HasForeignKey("CriancasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("academiadospeixinhoscloud.Models.Subscricao", null)
                        .WithMany()
                        .HasForeignKey("SubscricaoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalaSubscricao", b =>
                {
                    b.HasOne("academiadospeixinhoscloud.Models.Sala", null)
                        .WithMany()
                        .HasForeignKey("SalasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("academiadospeixinhoscloud.Models.Subscricao", null)
                        .WithMany()
                        .HasForeignKey("SubscricoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Produto", b =>
                {
                    b.HasOne("academiadospeixinhoscloud.Models.Crianca", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CriancaId");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Sala", b =>
                {
                    b.HasOne("academiadospeixinhoscloud.Models.Ementa", null)
                        .WithMany("Salas")
                        .HasForeignKey("EmentaId");

                    b.HasOne("academiadospeixinhoscloud.Models.Evento", null)
                        .WithMany("Salas")
                        .HasForeignKey("EventoId");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Crianca", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Ementa", b =>
                {
                    b.Navigation("Salas");
                });

            modelBuilder.Entity("academiadospeixinhoscloud.Models.Evento", b =>
                {
                    b.Navigation("Salas");
                });
#pragma warning restore 612, 618
        }
    }
}
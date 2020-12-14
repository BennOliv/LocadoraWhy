﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteBackendJr.Repositories;

namespace TesteBackendJr.Migrations
{
    [DbContext(typeof(LocadoraContext))]
    [Migration("20201214080442_LocacaoReworkv2")]
    partial class LocacaoReworkv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TesteBackendJr.Models.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CPF")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TesteBackendJr.Models.Entities.Filme", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estoque")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<double>("PrecoLocacao")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("TesteBackendJr.Models.Entities.Locacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataLimiteDevolucao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("TEXT");

                    b.Property<long?>("FilmeId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorLocacao")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorMulta")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Locacaos");
                });

            modelBuilder.Entity("TesteBackendJr.Models.Entities.Locacao", b =>
                {
                    b.HasOne("TesteBackendJr.Models.Entities.Cliente", "Cliente")
                        .WithMany("Locacaos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("TesteBackendJr.Models.Entities.Filme", "Filme")
                        .WithMany("Locacaos")
                        .HasForeignKey("FilmeId");

                    b.Navigation("Cliente");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("TesteBackendJr.Models.Entities.Cliente", b =>
                {
                    b.Navigation("Locacaos");
                });

            modelBuilder.Entity("TesteBackendJr.Models.Entities.Filme", b =>
                {
                    b.Navigation("Locacaos");
                });
#pragma warning restore 612, 618
        }
    }
}

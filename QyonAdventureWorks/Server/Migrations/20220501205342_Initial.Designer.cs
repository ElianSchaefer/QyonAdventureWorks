// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QyonAdventureWorks.Server.Data;

#nullable disable

namespace QyonAdventureWorks.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220501205342_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QyonAdventureWorks.Shared.Model.CompetidorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("TemperaturaCorporal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Competidores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Altura = 1.85m,
                            Nome = "Pedro Matinelli",
                            Peso = 85m,
                            Sexo = "M",
                            TemperaturaCorporal = 37m
                        },
                        new
                        {
                            Id = 2,
                            Altura = 1.80m,
                            Nome = "Bruno Amparo",
                            Peso = 90m,
                            Sexo = "M",
                            TemperaturaCorporal = 36.8m
                        },
                        new
                        {
                            Id = 3,
                            Altura = 1.70m,
                            Nome = "Marcela Fontes",
                            Peso = 70m,
                            Sexo = "F",
                            TemperaturaCorporal = 36.5m
                        });
                });

            modelBuilder.Entity("QyonAdventureWorks.Shared.Model.HistoricoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompetidorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCorrida")
                        .HasColumnType("datetime2");

                    b.Property<int>("PistaId")
                        .HasColumnType("int");

                    b.Property<decimal>("TempoGasto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Historicos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompetidorId = 1,
                            DataCorrida = new DateTime(2022, 5, 1, 17, 53, 41, 812, DateTimeKind.Local).AddTicks(7767),
                            PistaId = 1,
                            TempoGasto = 1.30m
                        },
                        new
                        {
                            Id = 2,
                            CompetidorId = 1,
                            DataCorrida = new DateTime(2022, 5, 1, 17, 53, 41, 812, DateTimeKind.Local).AddTicks(7777),
                            PistaId = 2,
                            TempoGasto = 1.50m
                        },
                        new
                        {
                            Id = 3,
                            CompetidorId = 2,
                            DataCorrida = new DateTime(2022, 5, 1, 17, 53, 41, 812, DateTimeKind.Local).AddTicks(7778),
                            PistaId = 2,
                            TempoGasto = 1.40m
                        });
                });

            modelBuilder.Entity("QyonAdventureWorks.Shared.Model.PistaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pistas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Pista com 5 curvas acentuadas dentro da cidade!"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Pista com percurso Rural!"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Pista percurso rally com rampa!"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

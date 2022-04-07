﻿// <auto-generated />
using MedService.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestPostgreSqlEnum;

#nullable disable

namespace TestPostgreSqlEnum.Migrations.TempDb
{
    [DbContext(typeof(TempDbContext))]
    [Migration("20220407160400_InitialTemp")]
    partial class InitialTemp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("temp")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "temp", "temp_enum_type", new[] { "value1", "value2" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestPostgreSqlEnum.TempModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TempEnumType>("TempEnum")
                        .HasColumnType("temp.temp_enum_type");

                    b.HasKey("Id");

                    b.ToTable("Temps", "temp");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test1.Models;

#nullable disable

namespace Test1.Migrations
{
    [DbContext(typeof(CasasdbContext))]
    [Migration("20230816221823_casas_migracion")]
    partial class casas_migracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Test1.Models.Venta_Casas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.Property<string>("moredescripcion")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("photo")
                        .HasColumnType("longtext");

                    b.Property<int?>("precio")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("venta_casas_tb", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

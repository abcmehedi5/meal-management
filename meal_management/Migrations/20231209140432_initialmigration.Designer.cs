﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using meal_management.Data;

#nullable disable

namespace meal_management.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231209140432_initialmigration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("meal_management.Model.MealManageModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Refund")
                        .HasColumnType("int");

                    b.Property<int?>("diposit")
                        .HasColumnType("int");

                    b.Property<int?>("due")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("meal")
                        .HasColumnType("int");

                    b.Property<double>("mealRate")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalCost")
                        .HasColumnType("float");

                    b.Property<int>("totalMeal")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("meals");
                });
#pragma warning restore 612, 618
        }
    }
}

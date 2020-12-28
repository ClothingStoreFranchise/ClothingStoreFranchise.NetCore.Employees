﻿// <auto-generated />
using ClothingStoreFranchise.NetCore.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClothingStoreFranchise.NetCore.Employees.Migrations.EmployeesMigrations
{
    [DbContext(typeof(EmployeesContext))]
    partial class EmployeesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClothingStoreFranchise.NetCore.Employees.Model.Building", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Building");
                });

            modelBuilder.Entity("ClothingStoreFranchise.NetCore.Employees.Model.FranchiseEmployee", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSecurityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empoyees");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FranchiseEmployee");
                });

            modelBuilder.Entity("ClothingStoreFranchise.NetCore.Employees.Model.Shop", b =>
                {
                    b.HasBaseType("ClothingStoreFranchise.NetCore.Employees.Model.Building");

                    b.HasDiscriminator().HasValue("Shop");
                });

            modelBuilder.Entity("ClothingStoreFranchise.NetCore.Employees.Model.Warehouse", b =>
                {
                    b.HasBaseType("ClothingStoreFranchise.NetCore.Employees.Model.Building");

                    b.HasDiscriminator().HasValue("Warehouse");
                });

            modelBuilder.Entity("ClothingStoreFranchise.NetCore.Employees.Model.ShopEmployee", b =>
                {
                    b.HasBaseType("ClothingStoreFranchise.NetCore.Employees.Model.FranchiseEmployee");

                    b.Property<long>("ShopId")
                        .HasColumnType("bigint");

                    b.HasIndex("ShopId");

                    b.HasDiscriminator().HasValue("ShopEmployee");
                });

            modelBuilder.Entity("ClothingStoreFranchise.NetCore.Employees.Model.WarehouseEmployee", b =>
                {
                    b.HasBaseType("ClothingStoreFranchise.NetCore.Employees.Model.FranchiseEmployee");

                    b.Property<long>("WarehouseId")
                        .HasColumnType("bigint");

                    b.HasIndex("WarehouseId");

                    b.HasDiscriminator().HasValue("WarehouseEmployee");
                });

            modelBuilder.Entity("ClothingStoreFranchise.NetCore.Employees.Model.ShopEmployee", b =>
                {
                    b.HasOne("ClothingStoreFranchise.NetCore.Employees.Model.Shop", "Shop")
                        .WithMany("ShopEmployees")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ClothingStoreFranchise.NetCore.Employees.Model.WarehouseEmployee", b =>
                {
                    b.HasOne("ClothingStoreFranchise.NetCore.Employees.Model.Warehouse", "Warehouse")
                        .WithMany("WarehouseEmployees")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantManagement.Data.Context;

#nullable disable

namespace RestaurantManagement.Migrations
{
    [DbContext(typeof(RestaurentManagementContext))]
    partial class RestaurentManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.AttendanceTypes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AttendanceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("attendancetype");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.EmployeAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttendanceType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceType");

                    b.ToTable("employeattendance");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Menus", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("MenuId");

                    b.ToTable("menu");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<bool>("IsCustomerActive")
                        .HasColumnType("bit");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("MenuId");

                    b.HasIndex("TableId");

                    b.HasIndex("UserId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Roles", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Tables", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<int>("SettingCapacity")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.ToTable("table");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EnrolleddDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Role");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.EmployeAttendance", b =>
                {
                    b.HasOne("Restaurant_Management_API.Models.Entity.AttendanceTypes", "AttendanceTypes")
                        .WithMany("EmployeAttendances")
                        .HasForeignKey("AttendanceType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttendanceTypes");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Orders", b =>
                {
                    b.HasOne("Restaurant_Management_API.Models.Entity.Menus", "Menus")
                        .WithMany("Orders")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant_Management_API.Models.Entity.Tables", "Tables")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant_Management_API.Models.Entity.Users", "user")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menus");

                    b.Navigation("Tables");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Users", b =>
                {
                    b.HasOne("Restaurant_Management_API.Models.Entity.Roles", "Roles")
                        .WithMany("user")
                        .HasForeignKey("Role");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.AttendanceTypes", b =>
                {
                    b.Navigation("EmployeAttendances");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Menus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Roles", b =>
                {
                    b.Navigation("user");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Tables", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Restaurant_Management_API.Models.Entity.Users", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shipping_Management_Application.Data;

#nullable disable

namespace Shipping_Management_Application.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Shipping_Management_Application.BuisnessLogic.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shipping_Management_Application.BuisnessLogic.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserEntities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Shipping_Management_Application.Data.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Admin", b =>
                {
                    b.HasBaseType("Shipping_Management_Application.BuisnessLogic.UserEntity");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Shipping_Management_Application.BuisnessLogic.User.User", b =>
                {
                    b.HasBaseType("Shipping_Management_Application.BuisnessLogic.UserEntity");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Shipping_Management_Application.BuisnessLogic.Order", b =>
                {
                    b.HasOne("Shipping_Management_Application.Data.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Shipping_Management_Application.Data.Customer", b =>
                {
                    b.HasOne("Shipping_Management_Application.BuisnessLogic.User.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("Shipping_Management_Application.Data.Customer", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shipping_Management_Application.Data.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shipping_Management_Application.BuisnessLogic.User.User", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

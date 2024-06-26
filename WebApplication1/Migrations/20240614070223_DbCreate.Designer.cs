﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Context;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240614070223_DbCreate")]
    partial class DbCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Client", b =>
                {
                    b.Property<int>("IdCient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCient"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WebApplication1.Models.Discount", b =>
                {
                    b.Property<int>("IdDiscount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDiscount"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdSubscription")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("IdDiscount");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("WebApplication1.Models.Payment", b =>
                {
                    b.Property<int>("IdPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPayment"));

                    b.Property<int?>("ClientIdCient")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdSubscription")
                        .HasColumnType("int");

                    b.HasKey("IdPayment");

                    b.HasIndex("ClientIdCient");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WebApplication1.Models.Sale", b =>
                {
                    b.Property<int>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSale"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdSubscription")
                        .HasColumnType("int");

                    b.HasKey("IdSale");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdSubscription");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("WebApplication1.Models.Subscription", b =>
                {
                    b.Property<int>("IdSubscription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSubscription"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RenewalMethod")
                        .HasColumnType("int");

                    b.HasKey("IdSubscription");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("WebApplication1.Models.Payment", b =>
                {
                    b.HasOne("WebApplication1.Models.Client", null)
                        .WithMany("Payments")
                        .HasForeignKey("ClientIdCient");
                });

            modelBuilder.Entity("WebApplication1.Models.Sale", b =>
                {
                    b.HasOne("WebApplication1.Models.Client", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("IdSubscription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("WebApplication1.Models.Client", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}

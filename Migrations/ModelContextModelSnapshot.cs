﻿// <auto-generated />
using System;
using ECommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce.Infrastructure.DataModel.CategoryDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<Guid?>("Parent")
                        .HasColumnName("Parent");

                    b.Property<long>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("Parent");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommerce.Infrastructure.DataModel.ItemDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BuyPrice")
                        .HasColumnName("BuyPrice");

                    b.Property<Guid>("CategoryId")
                        .HasColumnName("CategoryId");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<string>("Note")
                        .HasColumnName("Note");

                    b.Property<string>("Picture")
                        .HasColumnName("Picture");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Quantity")
                        .HasDefaultValue(0);

                    b.Property<decimal>("Ranking")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ranking")
                        .HasDefaultValue(0m);

                    b.Property<bool>("SellAvaialable")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SellAvaialable")
                        .HasDefaultValue(false);

                    b.Property<decimal?>("SellPrice")
                        .HasColumnName("SellPrice");

                    b.Property<long>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ECommerce.Infrastructure.DataModel.OrderDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnName("DeliveryDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnName("OrderDate");

                    b.Property<int>("OrderNo")
                        .HasColumnName("OrderNo");

                    b.Property<int>("OrderStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderStatus")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnName("ShipDate");

                    b.Property<long>("StoreId");

                    b.Property<decimal>("Total")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Total")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ECommerce.Infrastructure.DataModel.OrderItemDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("ItemId")
                        .HasColumnName("ItemId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<Guid>("OrderId")
                        .HasColumnName("OrderId");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnName("PricePerUnit");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Quantity")
                        .HasDefaultValue(1);

                    b.Property<long>("StoreId");

                    b.Property<decimal>("Total")
                        .HasColumnName("Total");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ECommerce.Infrastructure.DataModel.CategoryDto", b =>
                {
                    b.HasOne("ECommerce.Infrastructure.DataModel.CategoryDto", "_Parent")
                        .WithMany("_Children")
                        .HasForeignKey("Parent");
                });

            modelBuilder.Entity("ECommerce.Infrastructure.DataModel.ItemDto", b =>
                {
                    b.HasOne("ECommerce.Infrastructure.DataModel.CategoryDto", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ECommerce.Infrastructure.DataModel.OrderItemDto", b =>
                {
                    b.HasOne("ECommerce.Infrastructure.DataModel.ItemDto", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Infrastructure.DataModel.OrderDto", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

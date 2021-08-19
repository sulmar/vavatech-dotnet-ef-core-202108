﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vavatech.EFCore.DbRepositories;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerCustomerGroup", b =>
                {
                    b.Property<int>("CustomerGroupsId")
                        .HasColumnType("int");

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.HasKey("CustomerGroupsId", "CustomersId");

                    b.HasIndex("CustomersId");

                    b.ToTable("CustomerCustomerGroup");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Login")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers", t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("ContentType");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("datetime");

                    b.Property<string>("FileName")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("FileName");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.AttachmentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("ContentType");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("datetime");

                    b.Property<string>("FileName")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("FileName");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<decimal>("Credit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(100m);

                    b.Property<string>("CustomerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]", true);

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .IsFixedLength(true);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Pesel")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Include", new[] { "FirstName", "LastName" });

                    b.HasIndex("FirstName", "LastName");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.CustomerGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("CustomerGroups");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.LoyaltyCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("LoyaltyCards");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.TotalAmountCountry", b =>
                {
                    b.Property<string>("Country")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable(null);

                    b.ToView("vwTotalAmountByCountry", "dbo");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Product", b =>
                {
                    b.HasBaseType("Sulmar.EFCore.Models.Item");

                    b.Property<string>("Color")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Service", b =>
                {
                    b.HasBaseType("Sulmar.EFCore.Models.Item");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CustomerCustomerGroup", b =>
                {
                    b.HasOne("Sulmar.EFCore.Models.CustomerGroup", null)
                        .WithMany()
                        .HasForeignKey("CustomerGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sulmar.EFCore.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Attachment", b =>
                {
                    b.HasOne("Sulmar.EFCore.Models.Order", null)
                        .WithMany("Attachments")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.AttachmentDetail", b =>
                {
                    b.HasOne("Sulmar.EFCore.Models.Attachment", null)
                        .WithOne("AttachmentDetail")
                        .HasForeignKey("Sulmar.EFCore.Models.AttachmentDetail", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Customer", b =>
                {
                    b.OwnsOne("Sulmar.EFCore.Models.Address", "InvoiceAddress", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasMaxLength(250)
                                .IsUnicode(false)
                                .HasColumnType("varchar(250)");

                            b1.Property<string>("Country")
                                .HasMaxLength(250)
                                .IsUnicode(false)
                                .HasColumnType("varchar(250)");

                            b1.Property<string>("Street")
                                .HasMaxLength(250)
                                .IsUnicode(false)
                                .HasColumnType("varchar(250)");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(250)
                                .IsUnicode(false)
                                .HasColumnType("varchar(250)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Sulmar.EFCore.Models.Address", "ShipAddress", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("InvoiceAddress");

                    b.Navigation("ShipAddress");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.LoyaltyCard", b =>
                {
                    b.HasOne("Sulmar.EFCore.Models.Customer", "Owner")
                        .WithOne("LoyaltyCard")
                        .HasForeignKey("Sulmar.EFCore.Models.LoyaltyCard", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Order", b =>
                {
                    b.HasOne("Sulmar.EFCore.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.OrderDetail", b =>
                {
                    b.HasOne("Sulmar.EFCore.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("Sulmar.EFCore.Models.Order", "Order")
                        .WithMany("Details")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Product", b =>
                {
                    b.HasOne("Sulmar.EFCore.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Sulmar.EFCore.Models.Product", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Service", b =>
                {
                    b.HasOne("Sulmar.EFCore.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Sulmar.EFCore.Models.Service", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Attachment", b =>
                {
                    b.Navigation("AttachmentDetail");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Customer", b =>
                {
                    b.Navigation("LoyaltyCard");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Sulmar.EFCore.Models.Order", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShopInventory;

#nullable disable

namespace PetShopInventory.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetShopInventory.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin",
                            Password = "123456"
                        });
                });

            modelBuilder.Entity("PetShopInventory.FeedingScheduleUtitlity.FeedingSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FeedingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.ToTable("FeedingSchedules");
                });

            modelBuilder.Entity("PetShopInventory.PetsPurchaseUtility.PetPurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PetPurchases");
                });

            modelBuilder.Entity("PetShopInventory.PetsUtility.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CageId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetPrice")
                        .HasColumnType("int");

                    b.Property<int?>("PetPurchaseId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.HasIndex("PetPurchaseId");

                    b.ToTable("Pets", (string)null);
                });

            modelBuilder.Entity("PetShopInventory.PetsUtility.PetCage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PetCages");
                });

            modelBuilder.Entity("PetShopInventory.FeedingScheduleUtitlity.FeedingSchedule", b =>
                {
                    b.HasOne("PetShopInventory.PetsUtility.PetCage", "Cage")
                        .WithMany("PetCageFeedingSchedules")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cage");
                });

            modelBuilder.Entity("PetShopInventory.PetsUtility.Pet", b =>
                {
                    b.HasOne("PetShopInventory.PetsUtility.PetCage", "Cage")
                        .WithMany("PetsList")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetShopInventory.PetsPurchaseUtility.PetPurchase", "PetPurchase")
                        .WithMany("PurchasedPets")
                        .HasForeignKey("PetPurchaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cage");

                    b.Navigation("PetPurchase");
                });

            modelBuilder.Entity("PetShopInventory.PetsPurchaseUtility.PetPurchase", b =>
                {
                    b.Navigation("PurchasedPets");
                });

            modelBuilder.Entity("PetShopInventory.PetsUtility.PetCage", b =>
                {
                    b.Navigation("PetCageFeedingSchedules");

                    b.Navigation("PetsList");
                });
#pragma warning restore 612, 618
        }
    }
}

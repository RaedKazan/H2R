﻿// <auto-generated />
using System;
using ApplicationDomianEntity.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationDomianEntity.Migrations
{
    [DbContext(typeof(R2HDbContext))]
    [Migration("20190610190342_wish-list")]
    partial class wishlist
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationDomianEntity.Models.JuiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId");

                    b.Property<double?>("BuyingPrice");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int>("ElectricCigaretMangmentId");

                    b.Property<byte[]>("Image");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<string>("Name");

                    b.Property<double?>("SellingPrice");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("JuiceItem");
                });

            modelBuilder.Entity("ApplicationDomianEntity.Models.ShopItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId");

                    b.Property<double?>("BuyingPrice");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int>("ElectricCigaretMangmentId");

                    b.Property<byte[]>("Image");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<string>("Name");

                    b.Property<double?>("SellingPrice");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ShopItem");
                });

            modelBuilder.Entity("ApplicationDomianEntity.Models.ShopItemLookUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Brand");

                    b.Property<int>("Category");

                    b.Property<string>("Description");

                    b.Property<double>("NicotinePercentage");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("ShopItemLookUp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = 0,
                            Category = 0,
                            Description = "ECigaert -سيقارة الكترونية",
                            NicotinePercentage = 0.0,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Brand = 0,
                            Category = 0,
                            Description = "EJuic -عصير الكتروني",
                            NicotinePercentage = 0.0,
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            Brand = 0,
                            Category = 0,
                            Description = "Vape -فيب الكترونية",
                            NicotinePercentage = 0.0,
                            Type = 3
                        },
                        new
                        {
                            Id = 4,
                            Brand = 1,
                            Category = 0,
                            Description = "عصير الكترونية",
                            NicotinePercentage = 0.0,
                            Type = 2
                        });
                });

            modelBuilder.Entity("ApplicationDomianEntity.Models.ShopItemMangment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Brand");

                    b.Property<int>("Category");

                    b.Property<int?>("ElectricCigaretId");

                    b.Property<bool>("IsAvilable");

                    b.Property<int?>("JuiceId");

                    b.Property<int?>("TotalyAvilable");

                    b.Property<int?>("TotalyInserted");

                    b.Property<int>("TotalySold");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ElectricCigaretId");

                    b.HasIndex("JuiceId");

                    b.ToTable("ShopItemMangment");
                });

            modelBuilder.Entity("ApplicationDomianEntity.Models.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("JuiceItemId");

                    b.Property<int>("ShopItemId");

                    b.Property<int>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("JuiceItemId");

                    b.HasIndex("ShopItemId");

                    b.HasIndex("UserId1");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("R2H.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("R2H.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Street");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ApplicationDomianEntity.Models.JuiceItem", b =>
                {
                    b.HasOne("ApplicationDomianEntity.Models.ShopItemLookUp", "Brand")
                        .WithMany("JuiceBrand")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ApplicationDomianEntity.Models.ShopItemLookUp", "Category")
                        .WithMany("JuiceCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ApplicationDomianEntity.Models.ShopItem", b =>
                {
                    b.HasOne("ApplicationDomianEntity.Models.ShopItemLookUp", "Brand")
                        .WithMany("ShopItemBrand")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ApplicationDomianEntity.Models.ShopItemLookUp", "Category")
                        .WithMany("ShopItemCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ApplicationDomianEntity.Models.ShopItemMangment", b =>
                {
                    b.HasOne("ApplicationDomianEntity.Models.ShopItem", "ElectricCigaret")
                        .WithMany("ElectricCigaretMangment")
                        .HasForeignKey("ElectricCigaretId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ApplicationDomianEntity.Models.JuiceItem", "JuiceItem")
                        .WithMany("ElectricCigaretMangment")
                        .HasForeignKey("JuiceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ApplicationDomianEntity.Models.WishList", b =>
                {
                    b.HasOne("ApplicationDomianEntity.Models.JuiceItem", "JuiceItem")
                        .WithMany("WishList")
                        .HasForeignKey("JuiceItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationDomianEntity.Models.ShopItem", "ShopItem")
                        .WithMany("WishList")
                        .HasForeignKey("ShopItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("R2H.Models.ApplicationUser", "User")
                        .WithMany("WishList")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("R2H.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("R2H.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("R2H.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("R2H.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("R2H.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("R2H.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

using ApplicationDomianEntity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomianEntity.ApplicationDbContext
{

    public partial class R2HDbContext : IdentityDbContext
    {
        public virtual DbSet<ShopItem> ShopItem { get; set; }
        public virtual DbSet<ShopItemLookUp> ShopItemLookUp { get; set; }
        public virtual DbSet<ShopItemMangment> ShopItemMangment { get; set; }

        public R2HDbContext(DbContextOptions<R2HDbContext> options)
          : base(options)
        {

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }

            catch (DbUpdateException dbu)
            {
                var exception = HandleDbUpdateException(dbu);
                throw exception;
            }

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                return await base.SaveChangesAsync();
            }

            catch (DbUpdateException dbu)
            {
                var exception = HandleDbUpdateException(dbu);
                throw exception;
            }
        }

        private Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data for lookups

            modelBuilder.Entity<ShopItemLookUp>().HasData(
                new ShopItemLookUp
                {
                    Id = 1,
                    Type = 1,
                    Description = "ECigaert -سيقارة الكترونية"
                }
            );
            modelBuilder.Entity<ShopItemLookUp>().HasData(
               new ShopItemLookUp
               {
                   Id = 2,
                   Type = 2,
                   Description = "EJuic -عصير الكتروني"
               }
           );
            modelBuilder.Entity<ShopItemLookUp>().HasData(
               new ShopItemLookUp
               {
                   Id = 3,
                   Type = 3,
                   Description = "Vape -فيب الكترونية"
               }
           );
            modelBuilder.Entity<ShopItemLookUp>().HasData(
            new ShopItemLookUp
            {
                Id = 4,
                Type = 1,
                Category = 1,
                Description = "سيقارة الكترونية"
            }
        );

            modelBuilder.Entity<ShopItemLookUp>().HasData(
         new ShopItemLookUp
         {
             Id = 5,
             Type = 1,
             Category = 2,
             Description = "بود سيقارة الكترونية"
         }
     );
            modelBuilder.Entity<ShopItemLookUp>().HasData(
            new ShopItemLookUp
            {
                Id = 6,
                Type = 1,
                Brand = 1,
                Description = "Smoke"
            }
        );
            modelBuilder.Entity<ShopItemLookUp>().HasData(
            new ShopItemLookUp
            {
                Id = 7,
                Type = 1,
                Brand = 2,
                Description = "Drag"
            }
        );


            modelBuilder.Entity<ShopItemLookUp>()
              .HasMany(e => e.ShopItemBrand)
              .WithOne(e => e.Brand)
              .HasForeignKey(e => e.BrandId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShopItemLookUp>()
             .HasMany(e => e.ShopItemType)
             .WithOne(e => e.Type)
             .HasForeignKey(e => e.TypeId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShopItemMangment>()
            .HasMany(e => e.ElectricCigaret)
            .WithOne(e => e.ElectricCigaretMangment)
            .HasForeignKey(e => e.ElectricCigaretMangmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }


}

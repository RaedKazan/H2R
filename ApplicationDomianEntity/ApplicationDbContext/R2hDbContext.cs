using ApplicationDomianEntity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using R2H.Models;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomianEntity.ApplicationDbContext
{

    public partial class R2HDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public virtual DbSet<ShopItem> ShopItem { get; set; }
        public virtual DbSet<ShopItemLookUp> ShopItemLookUp { get; set; }
        public virtual DbSet<ShopItemMangment> ShopItemMangment { get; set; }
        public virtual DbSet<JuiceItem> JuiceItem { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        // to be added later
        //public virtual DbSet<Images> Images { get; set; }

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
                Type = 2,
                Brand = 1,
                Description = "عصير الكترونية"
            }
        );



            modelBuilder.Entity<ShopItem>()
              .HasOne(e => e.Category)
              .WithMany(e => e.ShopItemCategory)
              .HasForeignKey(e => e.CategoryId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShopItem>()
             .HasOne(e => e.Brand)
             .WithMany(e => e.ShopItemBrand)
             .HasForeignKey(e => e.BrandId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShopItem>()
            .HasMany(e => e.ElectricCigaretMangment)
            .WithOne(e => e.ElectricCigaret)
            .HasForeignKey(e => e.ElectricCigaretId)
            .OnDelete(DeleteBehavior.Restrict);

            // to be add later
            //modelBuilder.Entity<ShopItem>()
            //.HasMany(e => e.Images)
            //.WithOne(e => e.ShopItem)
            //.HasForeignKey(e => e.ItemId)
            //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JuiceItem>()
            .HasMany(e => e.ElectricCigaretMangment)
            .WithOne(e => e.JuiceItem)
            .HasForeignKey(e => e.JuiceId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JuiceItem>()
             .HasOne(e => e.Category)
             .WithMany(e => e.JuiceCategory)
             .HasForeignKey(e => e.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JuiceItem>()
             .HasOne(e => e.Brand)
             .WithMany(e => e.JuiceBrand)
             .HasForeignKey(e => e.BrandId)
             .OnDelete(DeleteBehavior.Restrict);

            // to be add later
            //modelBuilder.Entity<JuiceItem>()
            //.HasMany(e => e.Images)
            //.WithOne(e => e.JuiceItem)
            //.HasForeignKey(e => e.JuiceId)
            //.OnDelete(DeleteBehavior.Restrict);


        }
    }


}

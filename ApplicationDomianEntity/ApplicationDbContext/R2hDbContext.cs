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
        public virtual DbSet<Class1> Class1 { get; set; }
        public virtual DbSet<Class2> Class2 { get; set; }
        public virtual DbSet<Class3> Class3 { get; set; }

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
            modelBuilder.Entity<Class1>().HasKey(entity => entity.Id);
            modelBuilder.Entity<Class2>().HasKey(entity => entity.Id);

            modelBuilder.Entity<Class2>()
         .HasOne(e => e.MyProperty)
         .WithMany(e => e.MyProperty)
         .HasForeignKey(e => e.class1)
         .OnDelete(DeleteBehavior.Restrict);
        }
    }


}

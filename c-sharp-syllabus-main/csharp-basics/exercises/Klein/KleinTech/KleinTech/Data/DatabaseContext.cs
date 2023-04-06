using Microsoft.EntityFrameworkCore;
using KleinTech.Models;

namespace KleinTech.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<SpouseDetails> SpouseDetails { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.SpouseDetails)
                .WithOne()
                .HasForeignKey<SpouseDetails>(s => s.PersonId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }   
}
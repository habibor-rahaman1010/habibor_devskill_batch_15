using Microsoft.EntityFrameworkCore;
using PetShopInventory.Account;
using PetShopInventory.DbContextUtility;
using PetShopInventory.FeedingScheduleUtitlity;
using PetShopInventory.PetsPurchaseUtility;
using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ApplicationDbContext() {
            _connectionString = ConnectionInfo.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(GetUser().ToList());
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Cage)
                .WithMany(c => c.PetsList)
                .HasForeignKey(p => p.CageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pet>().ToTable("Pets");

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.Cage)
                .WithMany(pc => pc.PetCageFeedingSchedules)
                .HasForeignKey(fs => fs.CageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PetPurchase>()
              .HasMany(pp => pp.PurchasedPets)
              .WithOne(p => p.PetPurchase)
              .HasForeignKey(p => p.PetPurchaseId)
              .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        private List<User> GetUser()
        {
            return new List<User> { new User { Id = 1, Name = "admin", Password = "123456" } };
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PetCage> PetCages { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<FeedingSchedule> FeedingSchedules { get; set; }
        public DbSet<PetPurchase> PetPurchases { get; set; }
    }
}

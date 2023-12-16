using Microsoft.EntityFrameworkCore;
using PetShopInventory.Account;
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

        public ApplicationDbContext()
        {
            _connectionString = "Server=HABIBOR-RAHAMAN\\SQLEXPRESS;Database=PetShopInventoryDB;User Id=habibor144369;Password=c++c++c#;Trust Server Certificate=True;";
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
            base.OnModelCreating(modelBuilder);
        }

        private List<User> GetUser()
        {
            return new List<User> { new User { Id = 1, Name = "admin", Password = "123456" } };
        }

        public DbSet<User> Users { get; set; }
    }
}

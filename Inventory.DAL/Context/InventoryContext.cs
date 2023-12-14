using Inventory.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DAL.Context
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
    }
}

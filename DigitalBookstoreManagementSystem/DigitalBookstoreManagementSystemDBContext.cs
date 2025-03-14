using System.Net.NetworkInformation;
using DigitalBookstoreManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem
{
    public class DigitalBookstoreManagementSystemDBContext : DbContext
    {   

        public DigitalBookstoreManagementSystemDBContext(DbContextOptions<DigitalBookstoreManagementSystemDBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }



        /* protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasKey(r => r.UserID);
            builder.Entity<User>()
                .Property(r => r.UserID)
                .ValueGeneratedOnAdd();

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithOne(r => r.Review);
        }
        */

        internal Book FirstOrDefaultAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

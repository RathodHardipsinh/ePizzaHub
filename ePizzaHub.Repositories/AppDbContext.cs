using ePizzaHub.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePizzaHub.Repositories
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=Shailendra\SqlExpress; initial catalog=ePizzaHubAzure;persist security info=True;user id=sa;password=dotnettricks; MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CartItem entity configuration
            modelBuilder.Entity<CartItem>()
                .Property(c => c.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // Item entity configuration
            modelBuilder.Entity<Item>()
                .Property(i => i.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // OrderItem entity configuration
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Total)
                .HasColumnType("decimal(18,2)");

            // PaymentDetails entity configuration
            modelBuilder.Entity<PaymentDetails>()
                .Property(p => p.GrandTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PaymentDetails>()
                .Property(p => p.Tax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PaymentDetails>()
                .Property(p => p.Total)
                .HasColumnType("decimal(18,2)");
        }
    }
}
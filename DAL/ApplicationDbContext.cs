using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Casher> Cashers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetials> OrderDetials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasOne(u => u.Casher)
                .WithOne(c => c.ApplicationUser)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Casher>().Property(a => a.Salary).HasColumnType("float");
            builder.Entity<Casher>().HasOne(c => c.Department)
                .WithMany(c => c.Cashers).HasForeignKey(c => c.Dept_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Casher>().HasMany(c => c.Orders)
                .WithOne(o => o.Casher).HasForeignKey(o => o.Casher_Id)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Customer>().Property(a => a.TotalTransactionsAmount).HasColumnType("float");
            builder.Entity<Customer>().HasMany(c => c.Orders)
                .WithOne(o => o.Customer).HasForeignKey(o => o.Customer_Id)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Department>().HasMany(d => d.Cashers)
                .WithOne(c => c.Department).HasForeignKey(c => c.Dept_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>().Property(a => a.TotalPrice).HasColumnType("float");
            builder.Entity<Order>().Property(a => a.Discount).HasColumnType("float");
            builder.Entity<Order>().HasMany(o => o.OrderDetials)
                .WithOne(Or => Or.Order).HasForeignKey(o => o.Order_Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderDetials>().Property(a => a.Price).HasColumnType("float");

            builder.Entity<Product>().Property(a => a.Price).HasColumnType("float");
            builder.Entity<Product>().HasMany(p => p.OrderDetials)
                .WithOne(o => o.Product).HasForeignKey(o => o.Order_Id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

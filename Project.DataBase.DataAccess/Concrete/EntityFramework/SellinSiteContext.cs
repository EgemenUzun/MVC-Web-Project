using Microsoft.EntityFrameworkCore;
using Project.DataBase.Entities.Concrete;
using SellingSites.Entities;

namespace Project.DataBase.DataAccess.Concrete.EntityFramework
{
    public class SellinSiteContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-59QQQHC;Database=Northwind;Trusted_Connection=true");
            optionsBuilder.UseNpgsql("User Id=postgres;Password=1234;Host=localhost;Database=Northwind1;Persist Security Info=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new {od.OrderId,od.ProductId});
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderdetails { get; set; }
        public DbSet<Shipper> shippers { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
    }
}

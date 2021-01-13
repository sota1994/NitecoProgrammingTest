using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace NitecoProgrammingTest.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
            .Property(o => o.Id)
            .ValueGeneratedOnAdd();


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() });
            // set relations
            modelBuilder.Entity<Order>().HasOne<Customer>(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>().HasOne<Product>(o => o.Product).WithMany(p => p.Orders).HasForeignKey(o => o.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasOne<Category>(p => p.Category).WithMany(ca => ca.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);

            //Seed data
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, Address = "TestCustomerAddress", Name = "TestCustomerName" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "TestCategoryName", Description = "TestCategoryDescription" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, CategoryId = 1, Description = "TestProductDescription", Name = "TestProductName", Price = 1.00, Quantity = 1 });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 1, Amount = 1, CustomerId = 1, OrderDate = DateTime.Now.Date, ProductId = 1 });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 2, Amount = 2, CustomerId = 1, OrderDate = DateTime.Now.Date, ProductId = 1 });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 3, Amount = 3, CustomerId = 1, OrderDate = DateTime.Now.Date, ProductId = 1 });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 4, Amount = 4, CustomerId = 1, OrderDate = DateTime.Now.Date, ProductId = 1 });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 5, Amount = 5, CustomerId = 1, OrderDate = DateTime.Now.Date, ProductId = 1 });
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}

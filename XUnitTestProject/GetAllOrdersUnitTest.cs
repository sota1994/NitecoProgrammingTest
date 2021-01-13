using System;
using Xunit;
using NitecoProgrammingTest.Pages.User;
using NitecoProgrammingTest.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace XUnitTestProject
{
    public class GetAllOrdersUnitTest
    {
      
        
        [Fact]
        public void GetAllOrdersCount()
        {

            
            //var userMainPage = new UserMainPageModel(_context, _logger);
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("Test");

            using (var db = new AppDbContext(optionsBuilder.Options))
            {
                db.Customers.Add(new Customer { Id = 1, Address = "TestCustomerAddress", Name = "TestCustomerName" });
                db.Categories.Add(new Category { Id = 1, Name = "TestCategoryName", Description = "TestCategoryDescription" });
                db.Products.Add( new Product { Id = 1, CategoryId = 1, Description = "TestProductDescription", Name = "TestProductName", Price = 1.00, Quantity = 1 });
                db.Orders.Add(new Order { Id = 1, Amount = 1, CustomerId = 1, OrderDate = DateTime.Now.Date, ProductId = 1 });
                db.SaveChanges();
                //Arrange
                var mock = new Mock<ILogger<UserMainPageModel>>();
                ILogger<UserMainPageModel> logger = mock.Object;
                var userMainPage = new UserMainPageModel(db, logger);

                //Act
                var expectedCount = db.Orders.ToList().Count;
                var actualCount = userMainPage.GetAllOrders().Count;
                //Assert

                Assert.Equal(expectedCount, actualCount);
            }
           
        }
        [Fact]
        public void GetAllOrdersWithCategoryCount()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase("Test");

            using (var db = new AppDbContext(optionsBuilder.Options))
            {

                db.Customers.Add(new Customer { Id = 1, Address = "TestCustomerAddress", Name = "TestCustomerName" });
                db.Categories.Add(new Category { Id = 1, Name = "TestCategoryName", Description = "TestCategoryDescription" });
                db.Products.Add(new Product { Id = 1, CategoryId = 1, Description = "TestProductDescription", Name = "TestProductName", Price = 1.00, Quantity = 1 });
                db.Orders.Add(new Order { Id = 1, Amount = 1, CustomerId = 1, OrderDate = DateTime.Now.Date, ProductId = 1 });
                db.SaveChanges();
                //Arrange
                var mock = new Mock<ILogger<UserMainPageModel>>();
                ILogger<UserMainPageModel> logger = mock.Object;
                

                //Arrange
                var userMainPage = new UserMainPageModel(db, logger);
                 var categoryName = "TestCategoryName";
                 //Act
                 var expectedCount = db.Orders
                                         .Include(o => o.Product)
                                         .ThenInclude(p => p.Category)
                                         .Where(o => o.Product.Category.Name.ToLower().Contains(categoryName.ToLower())).Count();

                 var actualCount = userMainPage.GetAllOrders(categoryName).Count;
                 //Assert

                 Assert.Equal(expectedCount, actualCount);
            }
        }
    }
}

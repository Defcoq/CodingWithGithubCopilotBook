using System.Threading.Tasks;
using ECommerce.DAL;
using ECommerce.DAL.Repositories;
using ECommerce.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ECommerce.Tests.DAL
{
    public class ProductRepositoryTests
    {
        private readonly DbContextOptions<ECommerceDbContext> _options;

        public ProductRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ECommerceDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task AddProduct_ShouldAddProduct()
        {
            using (var context = new ECommerceDbContext(_options))
            {
                var repository = new ProductRepository(context);
                var product = new Product { Name = "Test Product", Description = "Test Description", Price = 10.0m, CategoryId = 1 };

                await repository.AddAsync(product);

                var addedProduct = await context.Products.FirstOrDefaultAsync(p => p.Name == "Test Product");
                Assert.NotNull(addedProduct);
            }
        }

        // Aggiungi altri test per Update, Delete, GetAll, ecc.
    }
}
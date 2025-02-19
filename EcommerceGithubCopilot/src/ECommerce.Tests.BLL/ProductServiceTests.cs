using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.BLL;
using ECommerce.BLL.DTOs;
using ECommerce.BLL.Services;
using ECommerce.DAL.Repositories;
using ECommerce.Model;
using Moq;
using Xunit;

namespace ECommerce.Tests.BLL
{
    public class ProductServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task AddProduct_ShouldReturnSuccess()
        {
            var request = new AddProductRequest { Name = "Test Product", Description = "Test Description", Price = 10.0m, CategoryId = 1 };
            var response = await _productService.AddProductAsync(request);

            Assert.True(response.Success);
            _productRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        // Aggiungi altri test per Update, Delete, GetAll, ecc.
    }
}
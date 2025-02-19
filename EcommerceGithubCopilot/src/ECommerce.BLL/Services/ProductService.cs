using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.BLL.DTOs;
using ECommerce.DAL.Repositories;
using ECommerce.Model;

namespace ECommerce.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product);
            return new AddProductResponse { Success = true };
        }

        public async Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.UpdateAsync(product);
            return new UpdateProductResponse { Success = true };
        }

        public async Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request)
        {
            await _productRepository.DeleteAsync(request.Id);
            return new DeleteProductResponse { Success = true };
        }

        public async Task<GetAllProductsResponse> GetAllProductsAsync(GetAllProductsRequest request)
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return new GetAllProductsResponse { Products = productDtos };
        }
    }
}
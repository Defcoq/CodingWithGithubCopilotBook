using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.BLL.DTOs;

namespace ECommerce.BLL.Services
{
    public interface IProductService
    {
        Task<AddProductResponse> AddProductAsync(AddProductRequest request);
        Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request);
        Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request);
        Task<GetAllProductsResponse> GetAllProductsAsync(GetAllProductsRequest request);
    }
}
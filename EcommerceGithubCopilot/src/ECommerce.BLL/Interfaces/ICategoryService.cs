using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.BLL.DTOs;

namespace ECommerce.BLL.Services
{
    public interface ICategoryService
    {
        Task<AddCategoryResponse> AddCategoryAsync(AddCategoryRequest request);
        Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest request);
        Task<DeleteCategoryResponse> DeleteCategoryAsync(DeleteCategoryRequest request);
        Task<GetAllCategoriesResponse> GetAllCategoriesAsync(GetAllCategoriesRequest request);
    }
}
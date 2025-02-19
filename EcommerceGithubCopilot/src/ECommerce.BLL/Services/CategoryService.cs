using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.BLL.DTOs;
using ECommerce.DAL.Repositories;
using ECommerce.Model;

namespace ECommerce.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<AddCategoryResponse> AddCategoryAsync(AddCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.AddAsync(category);
            return new AddCategoryResponse { Success = true };
        }

        public async Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.UpdateAsync(category);
            return new UpdateCategoryResponse { Success = true };
        }

        public async Task<DeleteCategoryResponse> DeleteCategoryAsync(DeleteCategoryRequest request)
        {
            await _categoryRepository.DeleteAsync(request.Id);
            return new DeleteCategoryResponse { Success = true };
        }

        public async Task<GetAllCategoriesResponse> GetAllCategoriesAsync(GetAllCategoriesRequest request)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return new GetAllCategoriesResponse { Categories = categoryDtos };
        }
    }
}
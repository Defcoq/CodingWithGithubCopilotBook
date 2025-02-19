using AutoMapper;
using ECommerce.BLL.DTOs;
using ECommerce.Model;

namespace ECommerce.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<AddCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<AddUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, UserDto>();
        }
    }
}
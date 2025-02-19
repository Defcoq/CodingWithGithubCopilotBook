namespace ECommerce.BLL.DTOs
{
    public class AddCategoryRequest : BaseRequest
    {
        public string Name { get; set; }
    }

    public class AddCategoryResponse : BaseResponse
    {
    }

    public class UpdateCategoryRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryResponse : BaseResponse
    {
    }

    public class DeleteCategoryRequest : BaseRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryResponse : BaseResponse
    {
    }

    public class GetAllCategoriesRequest : BaseRequest
    {
    }

    public class GetAllCategoriesResponse : BaseResponse
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
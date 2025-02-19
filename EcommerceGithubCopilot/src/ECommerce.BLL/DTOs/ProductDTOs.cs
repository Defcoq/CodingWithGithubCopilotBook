namespace ECommerce.BLL.DTOs
{
    public class AddProductRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

    public class AddProductResponse : BaseResponse
    {
    }

    public class UpdateProductRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateProductResponse : BaseResponse
    {
    }

    public class DeleteProductRequest : BaseRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProductResponse : BaseResponse
    {
    }

    public class GetAllProductsRequest : BaseRequest
    {
    }

    public class GetAllProductsResponse : BaseResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
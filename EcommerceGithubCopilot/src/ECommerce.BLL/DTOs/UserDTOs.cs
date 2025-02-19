namespace ECommerce.BLL.DTOs
{
    public class AddUserRequest : BaseRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AddUserResponse : BaseResponse
    {
    }

    public class UpdateUserRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserResponse : BaseResponse
    {
    }

    public class DeleteUserRequest : BaseRequest
    {
        public int Id { get; set; }
    }

    public class DeleteUserResponse : BaseResponse
    {
    }

    public class GetAllUsersRequest : BaseRequest
    {
    }

    public class GetAllUsersResponse : BaseResponse
    {
        public IEnumerable<UserDto> Users { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
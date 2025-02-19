using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.BLL.DTOs;

namespace ECommerce.BLL.Services
{
    public interface IUserService
    {
        Task<AddUserResponse> AddUserAsync(AddUserRequest request);
        Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request);
        Task<GetAllUsersResponse> GetAllUsersAsync(GetAllUsersRequest request);
    }
}
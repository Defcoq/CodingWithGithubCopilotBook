using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.BLL.DTOs;
using ECommerce.DAL.Repositories;
using ECommerce.Model;

namespace ECommerce.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AddUserResponse> AddUserAsync(AddUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user);
            return new AddUserResponse { Success = true };
        }

        public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.UpdateAsync(user);
            return new UpdateUserResponse { Success = true };
        }

        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request)
        {
            await _userRepository.DeleteAsync(request.Id);
            return new DeleteUserResponse { Success = true };
        }

        public async Task<GetAllUsersResponse> GetAllUsersAsync(GetAllUsersRequest request)
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return new GetAllUsersResponse { Users = userDtos };
        }
    }
}
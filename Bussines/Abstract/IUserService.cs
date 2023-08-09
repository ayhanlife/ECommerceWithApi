using Entities.Dtos.UserDtos;
using System.Linq.Expressions;

namespace Bussines.Abstract
{
    public interface IUserService
    {
        Task<List<UserDetailDto>> GetListAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> AddAsync(UserAddDto userAddDto);
        Task<UserDetailDto> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<bool> DeleteAsync(int id);

    }
}

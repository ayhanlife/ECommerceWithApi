using Core.Utilities.Response;
using Entities.Concrate;
using Entities.Dtos.User;
using System.Linq.Expressions;

namespace Bussines.Abstract
{
    public interface IUserService
    {
        //Task<ApiDataResponse<List<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null);
        Task<ApiDataResponse<List<UserDetailDto>>> GetListAsync();
        Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<AppUser, bool>> filter);
        Task<ApiDataResponse<UserDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto);
        Task<ApiDataResponse<UserDetailDto>> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
        //Task<ApiDataResponse<AccesToken>> Authenticate(UserForLoginDto userForLoginDto);

    }
}

using Core.Utilities.Response;
using Entities.Dtos.Auth;
using Entities.Dtos.User;

namespace Bussines.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}

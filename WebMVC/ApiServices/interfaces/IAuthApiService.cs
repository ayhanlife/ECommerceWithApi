using Core.Utilities.Response;
using Entities.Dtos.Auth;
using Entities.Dtos.User;

namespace WebMVC.ApiServices.interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto dto);
    }
}

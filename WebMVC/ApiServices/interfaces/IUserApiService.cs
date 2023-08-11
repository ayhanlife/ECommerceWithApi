using Entities.Dtos.User;

namespace WebMVC.ApiServices
{
    public interface IUserApiService
    {
        Task<List<UserDetailDto>> GetListAsync();
    }
}

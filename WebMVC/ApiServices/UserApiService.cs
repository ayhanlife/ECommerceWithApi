using Azure;
using Core.Utilities.Response;
using Entities.Dtos.User;
using Newtonsoft.Json;

namespace WebMVC.ApiServices
{
    public class UserApiService : IUserApiService
    {

        private readonly HttpClient _httpClient;
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDetailDto>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("Users/GetList");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            try
            {
                //var respa = response3.Content.ReadAsStringAsync();
                //gelenjson = respa.Result;
                //datalist = JsonConvert.DeserializeObject<GelenItem>(gelenjson);
                var responseess =   response.Content.ReadAsStringAsync();
                string gelenssjn = responseess.Result;
                var responseSuccess = await response.Content.ReadFromJsonAsync<ApiDataResponse<IEnumerable<UserDetailDto>>>();
                return responseSuccess.Data.ToList();
            //https://www.youtube.com/watch?v=WjhnBsUmCZg&list=PLE1HHxdKP5GEDq6MAjD8l2bDMtap7l0Hj&index=27
            }
            catch (Exception ex)
            {

                string message = ex.Message;
            }
                return null;

        }
    }
}

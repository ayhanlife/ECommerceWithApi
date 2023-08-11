using Entities.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.ApiServices;

namespace WebMVC.Controllers
{


    [Authorize]
    [Area("Admin")]

    public class UsersController : Controller
    {
        //private string url = "https://localhost:7194/api/";

        //private readonly HttpClient _httpClient;
        //public UsersController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}


        private readonly IUserApiService _userApiService;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public UsersController(IUserApiService userApiService, IHttpContextAccessor httpContextAccesor)
        {
            _userApiService = userApiService;
            _httpContextAccesor = httpContextAccesor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _userApiService.GetListAsync());
        }
    }
}

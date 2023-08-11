using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.ApiServices;
using WebMVC.ApiServices.interfaces;

namespace WebMVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserApiService _userApiService;
       
        public UserController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
            //_contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _userApiService.GetListAsync();
            if (result != null)
            {

            }
            return View(result);
        }
    }
}

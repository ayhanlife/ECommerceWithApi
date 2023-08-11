using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMVC.ApiServices.interfaces;

namespace WebMVC.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IAuthApiService _authApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthApiService authApiService, IHttpContextAccessor httpContextAccessor)
        {
            _authApiService = authApiService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _authApiService.LoginAsync(loginDto);
            if (user.Success)
            {
                _httpContextAccessor.HttpContext.Session.SetString("token", user.Data.Token);
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //userClaims.AddClaim(new Claim("token", user.Data.Token));
                userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()));
                userClaims.AddClaim(new Claim(ClaimTypes.Name, user.Data.UserName));

                var claimPrincipal = new ClaimsPrincipal(userClaims);
                var authProperties = new AuthenticationProperties() { IsPersistent = loginDto.IsRememberMe };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, authProperties);
                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("","Kullnıcı adı veya şifre yanlış");
            }
            return View();
        }
    }
}

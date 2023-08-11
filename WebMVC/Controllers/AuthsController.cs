using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMVC.ApiServices.interfaces;

namespace WebMVC.Controllers
{

    [Area("Admin")]
    public class AuthsController : Controller
    {
        private readonly IAuthApiService _authApiService;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public AuthsController(IAuthApiService authApiService, IHttpContextAccessor httpContextAccesor)
        {
            _authApiService = authApiService;
            _httpContextAccesor = httpContextAccesor;
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
            if (user != null && user.Success)
            {
                _httpContextAccesor.HttpContext.Session.SetString("token", user.Data.Token);
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()));
                userClaims.AddClaim(new Claim(ClaimTypes.Name, user.Data.UserName.ToString()));
                var claimPrincipal = new ClaimsPrincipal(userClaims);
                var autProperies = new AuthenticationProperties() { IsPersistent = loginDto.IsRememberMe };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, autProperies);

                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış, Lütfen tekrar deneyiniz.");
            }
            return View(loginDto);
        }
    }
}

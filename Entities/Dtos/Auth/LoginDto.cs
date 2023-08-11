namespace Entities.Dtos.Auth
{
    public class LoginDto
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsRememberMe { get; set; }
    }
}

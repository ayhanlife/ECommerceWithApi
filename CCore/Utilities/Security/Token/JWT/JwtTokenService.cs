using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Core.Utilities.Security.Token.JWT
{
    public class JwtTokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        public JwtTokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public AccesToken CreateToken(int userId, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,  Convert.ToString(userId)),
                    new Claim(ClaimTypes.Name,  userName),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return new AccesToken()
            {

                Token = tokenHandler.WriteToken(token),
                UserId = userId,
                UserName = userName,
                Expiration = (DateTime)tokenDescription.Expires,
            };

            //await Task.Run(() => accesToken);
        }
    }
}

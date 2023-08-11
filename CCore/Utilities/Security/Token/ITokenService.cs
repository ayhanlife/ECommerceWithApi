namespace Core.Utilities.Security.Token
{
    public interface ITokenService
    {
        AccesToken CreateToken(int userId, string userName);
    }
}

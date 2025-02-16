using Entities;

namespace Bussines.Security.Abstract
{
  public  interface ITokenService
    {
        Task<Token> CreateAccessTokenAsync(User User, List<string> roles);
        string CreateRefreshToken();
    }
}

using TodoApi.Models;

namespace TodoApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}

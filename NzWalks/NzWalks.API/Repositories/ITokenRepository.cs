using Microsoft.AspNetCore.Identity;

namespace NzWalks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}

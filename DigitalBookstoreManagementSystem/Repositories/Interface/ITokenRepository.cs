using Microsoft.AspNetCore.Identity;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}

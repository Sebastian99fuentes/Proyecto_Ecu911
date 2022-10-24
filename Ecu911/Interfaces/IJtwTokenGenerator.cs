using System.Security.Claims;

namespace Ecu911.Interfaces
{
    public interface IJtwTokenGenerator
    {
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}

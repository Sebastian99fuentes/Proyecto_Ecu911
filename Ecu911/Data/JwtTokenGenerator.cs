using System.Security.Claims;
using Ecu911.Interfaces;
using Ecu911.ResponseModels;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Ecu911.Data
{
    public class JwtTokenGenerator : IJtwTokenGenerator
    {
        private readonly JwtTokenModel jwtTokenConfig;
        public JwtTokenGenerator(JwtTokenModel jtm)
        {
            jwtTokenConfig = jtm;
        }
        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtValidationParams = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.ASCII.GetBytes(jwtTokenConfig.SigningKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };
                SecurityToken securityToken;
                var valid = tokenHandler.ValidateToken(token, jwtValidationParams, out securityToken);
                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return jwtSecurityToken.Claims;
                }
                else
                {
                    return null;
                }
            }
            catch (SecurityTokenExpiredException)
            {
                throw new SecurityTokenExpiredException("Sesion caducada");
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un problema con el token");
            }
        }

        public string GetTokenUser(string accesToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadJwtToken(accesToken);
            var claims = securityToken.Claims;
            string name = claims.ElementAt(2).Value;
            return name;
        }

        public string GetTokenRole(string accesToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadJwtToken(accesToken);
            var claims = securityToken.Claims;
            string name = claims.ElementAt(4).Value;
            return name;
        }
    }
}

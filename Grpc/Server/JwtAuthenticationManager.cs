using GrpcData;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server
{
    public class JwtAuthenticationManager : IJwtAuthenicationManager
    {
        public JwtAuthenticationManager(IConfiguration config)
        {
            _Config = config;
        }

        const int TOKEN_VALIDY = 1000;

        private IConfiguration _Config { get; }

        public async Task<AuthenticationReply?> AuthenticateAsync(AuthenticationRequest request)
        {
            return await Task.Run(() =>
            {
                if (request.Username != "admin" || request.Password != "admin")
                    return null;

                string tokenKeyFromConfig = _Config.GetSection("jwt").GetValue(typeof(string), "Key") as string ?? "";
                if (tokenKeyFromConfig is null)
                    return null;

                var jwtSecurityToken = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(tokenKeyFromConfig);
                var tokenExpiryDateTime = DateTime.Now.AddYears(TOKEN_VALIDY);
                var securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim("username", request.Username),
                        new Claim(ClaimTypes.Role, "Administrator")
                    }),
                    Expires = tokenExpiryDateTime,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var securityToken = jwtSecurityToken.CreateToken(securityTokenDescriptor);
                var token = jwtSecurityToken.WriteToken(securityToken);

                return new AuthenticationReply
                {
                    AccessToken = token,
                    ExpiresIn = (int)tokenExpiryDateTime.Subtract(DateTime.Now).TotalSeconds
                };
            });
            
        }

        public byte[]? GetTokenKey()
        {
            string tokenKeyFromConfig = _Config.GetSection("jwt").GetValue(typeof(string), "Key") as string ?? "";
            if (tokenKeyFromConfig is null)
                return null;

            return Encoding.ASCII.GetBytes(tokenKeyFromConfig);
        }
    }
}

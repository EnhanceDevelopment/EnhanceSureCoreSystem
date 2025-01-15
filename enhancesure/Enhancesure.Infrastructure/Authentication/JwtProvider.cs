using EnhanceSure.Application.Contracts.Infrastructure.Authentication;
using EnhanceSure.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EnhanceSure.Infrastructure.Authentication {
    public class JwtProvider: IJwtProvider {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options=options.Value;
        }


        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var signingCredentials = new SigningCredentials (key,SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email!),
                //new(ClaimTypes.Role, user.UserRoles),
            };

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims:claims,
                notBefore: null,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: signingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken( token);
        }
    }
}

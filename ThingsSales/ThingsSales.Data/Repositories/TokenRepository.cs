﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ThingsSales.Data.Common;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Model.Identity;

namespace ThingsSales.Data.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        public string CreateToken(ApplicationUser user)
        {
            List<Claim> claim = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var authSigningKeys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.KEY));

            var token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                expires: DateTime.Now.AddHours(3),
                claims: claim,
                signingCredentials: new SigningCredentials(authSigningKeys, SecurityAlgorithms.HmacSha256)
                );

            return JsonSerializer.Serialize(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}

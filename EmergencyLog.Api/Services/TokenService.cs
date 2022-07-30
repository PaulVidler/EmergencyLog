using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EmergencyLog.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmergencyLog.Api.Services
{
    public class TokenService
    {
        private IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                // you can add as many claims as you want here (other user info etc) but this token will be sent with every request
                // to the API, so you might only put in the things you might need when a user authenticates to the API
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("OrganisationId", user.OrganisationId.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // sign the token with a new key. This key needs to be 12 chars at least and this development key is NOT
            // secure and when it's time to publish, we will create a random string of text that is more secure.
            // We are only hard coding a simple string in there for now.

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1), // Token expires in x days/minutes from time of creation. 
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        // create RefreshToken method
        public RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return new RefreshToken {Token = Convert.ToBase64String(randomNumber)};
        }

    }
}

using FPCMMS.Application.Contracts.Identity;
using FPCMMS.Application.DTOs;
using FPCMMS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FPCMMS.Infrastructure.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        private ApplicationUser _user;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            if (_user == null)
            {
                throw new Exception($"User with {userForAuth.UserName} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(userForAuth.UserName, userForAuth.Password, userForAuth.RememberMe, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{userForAuth.UserName} aren't valid'.");
            }
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
        }

        public async Task<AuthenticationResponse> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            AuthenticationResponse response = new()
            {
                Id = _user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                Country = _user.Country,
                UserName = _user.UserName,
                Expiration = tokenOptions.ValidTo
            };

            return response;
        }
        //TODO static method
        private static SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim("fullName", _user.FirstName + " " + _user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                //new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"]),
                new Claim("uid", _user.Id)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
        public async Task<SignInResult> Login(UserForAuthenticationDto user)
        {
            _user = await _userManager.FindByNameAsync(user.UserName);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
            return result;
        }
    }
}

﻿using CleanArchitecture.Application.Constants;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                throw new Exception($"El usuario con email {request.Email} no existe");

            //var validatr = await _userManager.CheckPasswordAsync(user, request.Password);

            var resultado = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false);
            if (!resultado.Succeeded)
                throw new Exception($"Las credenciales son incorrectas");

            var token = await GenerateToken(user);
            return new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                Username = user.UserName
            };
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);
            if(existingUser != null)
                throw new Exception($"El username ya fue tomado por otra cuenta");

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null)
                throw new Exception($"El email ya fue tomado por otra cuenta");

            var user = new ApplicationUser
            {
                Email = request.Email,
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                UserName = request.Username,
                EmailConfirmed = true
            };

            var resultado = await _userManager.CreateAsync(user, request.Password);
            if (resultado.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Operator");
                var token = await GenerateToken(user);

                return new RegistrationResponse
                {
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = user.Id,
                    UserName = user.UserName
                };
            }

            throw new Exception($"{resultado.Errors}");
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var rol in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials                
                );

            return jwtSecurityToken;
        }
    }
}
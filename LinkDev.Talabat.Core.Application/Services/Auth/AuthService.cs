﻿using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Auth;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Auth;
using LinkDev.Talabat.Core.Application.Exceptions;
using LinkDev.Talabat.Core.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LinkDev.Talabat.Core.Application.Services.Auth
{
	internal class AuthService(
		UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager,
		IOptions<JwtSettings> jwtSettings
		) : IAuthService
	{

		private readonly JwtSettings _jwtSettings = jwtSettings.Value;

		public async Task<UserDto> RegisterAsync(RegisterDto model)
		{
			var user = new ApplicationUser() 
			{
				DisplayName = model.DisplayName,
				UserName = model.UserName,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
			};

			var result = await userManager.CreateAsync(user, model.Password);

			if (!result.Succeeded)
			{
				var errorDictionary = new Dictionary<string, string[]>();

				errorDictionary["General"] = result.Errors.Select(e => e.Description).ToArray();

				throw new ValidationException
				{
					Errors = errorDictionary
				};
			};

			var response = new UserDto()
			{
				Id = user.Id,
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = await GenerateTokenAsync(user)
			};

			return response;
		}

		public async Task<UserDto> LoginAsync(LoginDto model)
		{
			var user = await userManager.FindByEmailAsync(model.Email);

			if (user is null) throw new UnAuthorizedException("Invalid Login");

			var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: true);

			if (result.IsNotAllowed) throw new UnAuthorizedException("Account Not Confirmed Yet.");

			if (result.IsLockedOut) throw new UnAuthorizedException("Account Is Locked.");

			if(!result.Succeeded) throw new UnAuthorizedException("Invalid Login.");


			var response = new UserDto() 
			{
				Id = user.Id,
				DisplayName = user.DisplayName,
				Email = user.Email!,
				Token = await GenerateTokenAsync(user)
			};

			return response;
		}
	
		private async Task<string> GenerateTokenAsync(ApplicationUser user)
		{
			var userClaims = await userManager.GetClaimsAsync(user);
			var roleAsClaims = new List<Claim>();

			var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
				roleAsClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
			}

			var claims = new List<Claim>() 
			{
				new Claim(ClaimTypes.PrimarySid, user.Id),
				new Claim(ClaimTypes.Email, user.Email!),
				new Claim(ClaimTypes.GivenName, user.DisplayName)
			}.Union(userClaims)
			.Union(roleAsClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);


			var tokenObject = new JwtSecurityToken(
				issuer: _jwtSettings.Issure,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
				signingCredentials: signingCredentials
			);

			return new JwtSecurityTokenHandler().WriteToken(tokenObject);
		}
	}
}

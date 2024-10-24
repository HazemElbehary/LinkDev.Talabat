using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Auth;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Auth;
using LinkDev.Talabat.Core.Application.Exceptions;
using LinkDev.Talabat.Core.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;


namespace LinkDev.Talabat.Core.Application.Services.Auth
{
	internal class AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : IAuthService
	{
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
				Token = "This Will Be Token"
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

			var response = new UserDto() 
			{
				Id = user.Id,
				DisplayName = user.DisplayName,
				Email = user.Email!,
				Token = "This Will Be Token"
			};

			return response;
		}
	}
}

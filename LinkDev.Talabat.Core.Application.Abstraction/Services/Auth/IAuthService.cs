﻿using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Auth;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Auth
{
	public interface IAuthService
	{
		Task<UserDto> LoginAsync(LoginDto model);

		Task<UserDto> RegisterAsync(RegisterDto model);
	}
}
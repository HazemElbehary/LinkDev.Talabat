using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Auth;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs.Controllers.Controllers.Account
{
	public class AccountController(IServiceManager serviceManager) : BaseApiController
	{
		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto model)
		{
			var result = await serviceManager.AuthService.LoginAsync(model);
			return Ok(result);
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto model)
		{
			var result = await serviceManager.AuthService.RegisterAsync(model);
			return Ok(result);
		}
	}
}

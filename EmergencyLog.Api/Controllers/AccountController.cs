using System;
using System.Linq;
using EmergencyLog.Api.Services;
using EmergencyLog.Domain.Entities.Identity;
using EmergencyLog.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using EmergencyLog.Api.DTOs.IdentityDtos;
using Microsoft.AspNetCore.Http;

namespace EmergencyLog.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private DataContext _context;
        private TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, DataContext context, TokenService tokenService)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                await SetRefreshtoken(user);
                return CreateUserObject(user);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            // this will return a user object with a token, that automatically logs the user in if the registration is successful

            // check username etc does not already exist
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email is already taken");
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName))
            {
                return BadRequest("UserName is already taken");
            }

            var user = new AppUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                OrganisationId = registerDto.OrganisationId
            };
            
            var result = await _userManager.CreateAsync(user, registerDto.Password);


            if (!result.Succeeded) return BadRequest("There is a problem registering this user");

            await SetRefreshtoken(user);
            return CreateUserObject(user);
            
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            
            await SetRefreshtoken(user);
            return CreateUserObject(user);
        }

        [Authorize]
        [HttpPost("refreshToken")]
        public async Task<ActionResult<UserDto>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var user = await _userManager.Users
                .Include(r => r.RefreshTokens)
                .FirstOrDefaultAsync(x => x.UserName == User.FindFirstValue(ClaimTypes.Name));

            if (user == null) return Unauthorized();

            var oldToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken);

            if (oldToken != null && !oldToken.IsActive) return Unauthorized();

            if(oldToken != null) oldToken.Revoked = DateTime.UtcNow; // this was deleted accidentally?

            return CreateUserObject(user);
        }
        
        private async Task SetRefreshtoken(AppUser user)
        {
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshTokens.Add(refreshToken);

            await _userManager.UpdateAsync(user);

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // means our token is not accessible by javascript
                Expires = DateTime.UtcNow.AddDays(7),
            };

            // adds the refresh token to the response object
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
        
        // helper method to return UserDto
        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Image = null,
                Token = _tokenService.CreateToken(user),
                UserName = user.UserName,
                OrganisationId = user.OrganisationId
            };
        }

    }
}

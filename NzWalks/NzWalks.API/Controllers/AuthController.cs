using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.DTOs;
using NzWalks.API.Repositories;

namespace NzWalks.API.Controllers
{
   
    public class AuthController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityResult = await _userManager.CreateAsync(identityUser,registerRequestDto.Password);
            if(identityResult.Succeeded)
            {
                //Add Roles to the user
                identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                if(identityResult.Succeeded) 
                { 
                    return Ok("User registered Successfully");
                }
            }

            return BadRequest("Something Went Wrong!Try again");


        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user != null) 
            { 
                bool checkPassword=await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPassword)
                {
                    //get roles
                    var roles=await _userManager.GetRolesAsync(user); 
                    if (roles != null)
                    {
                        var token=tokenRepository.CreateToken(user, roles.ToList());
                        var jwtToken = new ResponseDto
                        {
                            jwtToken = token,
                        };
                        return Ok(jwtToken);    
                    }
                   
                }
                return BadRequest("Incorrect Password");    
            }

            return BadRequest("User Not Found");
        }
    }
}

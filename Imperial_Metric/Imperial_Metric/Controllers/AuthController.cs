using Imperial_Metric.Application.DTOS;
using Imperial_Metric.Application.DTOS.Auth;
using Imperial_Metric.Infrastructure.Context;
using Imperial_Metric.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imperial_Metric.WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class AuthController : BaseApiController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;
        private readonly ApplicationDbContext _context;
        public AuthController(UserManager<IdentityUser> userManager ,
            TokenService tokenService, ApplicationDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponseDto>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email);
            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (userInDb is null)
                return Unauthorized();
            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();
            return Ok(new AuthResponseDto
            {
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = accessToken,
            });
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _userManager.CreateAsync(
                new IdentityUser
                {
                    UserName = request.Username,
                    Email = request.Email
                },
                request.Password
                );

                if (result.Succeeded)
                {
                    request.Password = "";
                    return CreatedAtAction(nameof(Register), new { email = request.Email }, request);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return BadRequest(ModelState);
        }
    
    
    
    }


}

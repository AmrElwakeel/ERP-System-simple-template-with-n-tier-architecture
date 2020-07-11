using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAL.Core.Inrefaces;
using DAL.Entities;
using ERP.Dto.ApplicationUserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAccountManager accountManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public AuthorizationController(IAccountManager accountManager,SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.accountManager = accountManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUserDto userModel)
        {
            var User = await accountManager.GetUserByNameAsync(userModel.Name);
            if (User == null)
                return NotFound();
            if (!await accountManager.CheckUserPasswordAsync(User, userModel.Password))
                return BadRequest(new { message = "Invalid Username or password" });


            await signInManager.SignInAsync(User, isPersistent: false);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim("UserId",User.Id.ToString())
               }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                   new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApplicationSettings:JwtSecritKey"].ToString()))
                   , SecurityAlgorithms.HmacSha256Signature
                   )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var SecurityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(SecurityToken);
            return Ok(new { token});

        }
    }
}

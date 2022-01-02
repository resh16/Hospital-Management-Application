
using CustomIdentity.Models;
using MedLifeBL.Authentication_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedLife.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;



        public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
             

            var UserExist = await _userManager.FindByNameAsync(model.UserName);

            if (UserExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User Already Exist" });

            AppUser user = new AppUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                UserRole = model.Role

            };

            var result = await _userManager.CreateAsync(user, model.Password);
             await _userManager.AddToRoleAsync(user, user.UserRole);

            if (model.Password != model.Conform_Pwd)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Password and conform password does not match" });
            }
            else if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User Creation Failed" });

            }



            return Ok(new { Status = "Success", Message = "User Created Successfully" });
        }




        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.UserName);
                if (user != null)
                {


                    var result =
                        await _signInManager.CheckPasswordSignInAsync
                        (user, login.Password, false);

                    if (result.Succeeded)
                    {
                        //1  --16:28
                        var userRoles = await _userManager.GetRolesAsync(user);

                        //
                        var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        };

                        //2
                        foreach (var userRole in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole));


                        }

                        authClaims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));

                        //

                        var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                        var token = new JwtSecurityToken(
                           issuer: _configuration["JWT:ValidIssuer"],
                           audience: _configuration["JWT:ValidAudience"],
                           expires: DateTime.UtcNow.AddHours(3),
                           claims: authClaims,

                           signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256));
                        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });

                    }

                }
            }
            return Unauthorized();
        }





    }
}

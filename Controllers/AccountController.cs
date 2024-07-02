using FinalAppG.Data.DTOs;
using FinalAppG.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration configuration;

        public AccountController (UserManager<AppUser> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
            this.configuration=configuration;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> RegisterUser([FromForm]NewUserdto dto)
        {
            if (ModelState .IsValid)
            {
                AppUser appuser = new()
                {
                    FName = dto.FirstName,
                    LName = dto.LastName,
                    Password = dto.Password,
                    Email = dto.Email,
                    Gender = dto.Gender,
                    PhoneNumber = dto.Phone,
                    UserName=dto.UserName,
                    Address=dto.Address,
                    Government=dto.Government,
                    BirthDate=dto.birthday
                   


                };
                IdentityResult result = await _userManager.CreateAsync(appuser, dto.Password);

                if (result.Succeeded)
                {
                    return Ok("Succses");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }


            }
            return BadRequest(ModelState);
        }



        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromForm] Logindto dto)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await _userManager.FindByNameAsync(dto.username);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, dto.password))
                    {

                        return Ok("token");
                        var claims = new List<Claim>();

                        claims.Add(new Claim(ClaimTypes.Name, dto.username));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));

                        }

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);


                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: configuration["JWT:Issuer"],
                            audience: configuration["JWT:Audience"],
                            expires: DateTime.UtcNow.AddDays(10),
                            signingCredentials: sc
                            );

                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };
                        return Ok(_token);
                    }
                    else
                    {
                        return Unauthorized();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "UserName Or Passwor is  InValid");
                }
            }
            return BadRequest();
        }



    }
}

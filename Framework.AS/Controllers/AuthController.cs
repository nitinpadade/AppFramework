using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Framework.AS.Models;
using Framework.BL.Query.UserLogin;
using Framework.DomainModels.Models.UserLogin;
using Framework.DomainModels.Parameters.UserLogin;
using Framework.Factory;
using Framework.Factory.Client;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Framework.AS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly ICommandHandler _command;
        public readonly IQueryExecutor _query;
        public AuthController(ICommandHandler command, IQueryExecutor query)
        {
            _command = command;
            _query = query;
        }

        // GET api/values  
        [HttpPost, Route("login")]
        [EnableCors("Cors")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }

            var result = _query.Execute<UserLoginQuery, QueryResult<UserLoginModel>, UserLoginParameter>(new UserLoginParameter
            {
                UserName = user.UserName,
                Password = user.Password
            }).Data;

            if (result != null && result.IsAuthenticated)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44387",
                    audience: "http://localhost:4276",
                    claims: new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, result.Name),
                         new Claim("UserInfo", result.Id.ToString() + '|' + result.Name + '|' + result.RoleId.ToString())
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
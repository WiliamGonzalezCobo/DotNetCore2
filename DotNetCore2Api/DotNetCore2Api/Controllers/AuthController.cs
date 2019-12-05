using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore2Api.Model;
using DotNetCore2Api.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore2Api.Controllers
{
    [Route("api/autentication")]
    public class AuthController : Controller
    {
        private readonly IAuthService _iAuthService;
        public AuthController(IAuthService iAuthService)
        {
            _iAuthService = iAuthService;
        }

        [HttpPost("token")]
        public IActionResult token([FromBody]UserModel userData) {
            string token = string.Empty;
            DateTime dateNow = DateTime.UtcNow;
            TimeSpan timeStampExpired = TimeSpan.FromMinutes(30);
            DateTime dateExpired = dateNow.Add(timeStampExpired);

            if (_iAuthService.ValidateLogin(userData.User, userData.Password)) {
                token = _iAuthService.GenerateToken(dateNow, userData.User, timeStampExpired);

                return Ok(new {
                    Token = token,
                    ExpiredDateTime = dateExpired
                });
            }
            else {
                return StatusCode(401);
            }
        }

    }
}
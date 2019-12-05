using DotNetCore2Api.Services.Contract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCore2Api.Services
{
    public class AuthService:IAuthService
    {
        /// <summary>
        /// validacion del login 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool ValidateLogin(string user, string pass) {
            //validamos segun nuestro negocio
            return true;
        }

        /// <summary>
        /// Genera el token de autenticacion por JWT
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user"></param>
        /// <param name="validDate"></param>
        /// <returns></returns>
        public string GenerateToken(DateTime date, string user, TimeSpan validDate)
        {
            DateTime expire = date.Add(validDate);
            Claim[] claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Sub,user),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                        new DateTimeOffset(date)
                        .ToUniversalTime().ToUnixTimeSeconds().ToString(),
                        ClaimValueTypes.Integer64),
                new Claim("roles","Cliente"),
                new Claim("roles","Administrador")
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes("b87d3d19-9364-4b56-a8f0-7619ac5dcd65")),
                SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: "Ejemplo",
                audience: "Public",
                claims: claims,
                notBefore: date,
                expires: expire,
                signingCredentials: signingCredentials
                );

            string encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodeJwt;
        }
    }
}

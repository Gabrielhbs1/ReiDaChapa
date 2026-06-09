using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIReiDaChapa.Models;
using Microsoft.IdentityModel.Tokens;

namespace APIReiDaChapa.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Clientes cliente)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,
                    cliente.IdCliente.ToString()),

                new Claim(ClaimTypes.Name,
                    cliente.Nome),

                new Claim(ClaimTypes.Email,
                    cliente.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]));

            var credentials =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
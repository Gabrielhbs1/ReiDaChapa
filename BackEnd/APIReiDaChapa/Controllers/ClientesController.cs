using APIReiDaChapa.DTO;
using APIReiDaChapa.Models;
using APIReiDaChapa.Repository;
using APIReiDaChapa.Services;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace APIReiDaChapa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public ClientesController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // Criar Cliente
        [HttpPost("Registrar")]
        public async Task<IActionResult> CriarCliente([FromBody] NewClientes dto)
        {
            var emailExiste = await _context.Clientes
                .AnyAsync(c => c.Email == dto.Email);

            if (emailExiste)
                return BadRequest("E-mail já cadastrado.");

            var cliente = new Clientes
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Email = dto.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(BuscarCliente),
                new { id = cliente.IdCliente },
                cliente);
        }

        [HttpGet("List All")]
        public async Task<IActionResult> ListarClientes()
        {
            var clientes = await _context.Clientes
                .Select(c => new
                {
                    c.IdCliente,
                    c.Nome,
                    c.Telefone,
                    c.Email
                })
                .ToListAsync();

            return Ok(clientes);
        }

        // Buscar Cliente
        [HttpGet("Get By ID")]
        public async Task<IActionResult> BuscarCliente(int id)
        {
            var cliente = await _context.Clientes
                .Select(c => new
                {
                    c.IdCliente,
                    c.Nome,
                    c.Telefone,
                    c.Email
                })
                .FirstOrDefaultAsync(c => c.IdCliente == id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // Editar Cliente
        [HttpPut("Editar Cliente")]
        public async Task<IActionResult> EditarCliente(
            int id,
            [FromBody] NewClientes dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            cliente.Nome = dto.Nome;
            cliente.Telefone = dto.Telefone;
            cliente.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Senha))
            {
                cliente.Senha =
                    BCrypt.Net.BCrypt.HashPassword(dto.Senha);
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = "Cliente atualizado com sucesso."
            });
        }

        // Excluir Cliente
        [HttpDelete("Excluir Cliente")]
        public async Task<IActionResult> ExcluirCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = "Cliente removido com sucesso."
            });
        }

        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] loginDTO dto)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(
                    c => c.Email == dto.Email);

            if (cliente == null)
                return Unauthorized();

            bool senhaValida =
                BCrypt.Net.BCrypt.Verify(
                    dto.Senha,
                    cliente.Senha);

            if (!senhaValida)
                return Unauthorized();

            var token =
                _jwtService.GenerateToken(cliente);

            return Ok(new
            {
                token,
                cliente.IdCliente,
                cliente.Nome,
                cliente.Email
            });
        }
    }
}
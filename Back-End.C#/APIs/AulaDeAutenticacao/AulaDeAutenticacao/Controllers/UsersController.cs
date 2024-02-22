using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AulaDeAutenticacao.Data;
using AulaDeAutenticacao.Models;
using Microsoft.IdentityModel.Tokens;

namespace AulaDeAutenticacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AuthContextcs _context;

        public UsersController(AuthContextcs context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusuario()
        {
            return await _context.usuario.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.usuario.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Login(Dtos.UserDto user)
        {
            string token = "";
            var users = await _context.usuario.ToListAsync();
            var useLog = (from u in users where u.Username == user.username & u.Password == user.password select u).ToList();
            if (!useLog.IsNullOrEmpty())
            {
                 token = Config.Token.GenerateToken(useLog[0]);
            }
            return new { user = user, token = token };
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atividade1_API.Data;
using Atividade1_API.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.ExceptionServices;

namespace Atividade1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

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

        [HttpPost ("Login")]
        public async Task<ActionResult<dynamic>> Login(UserDto.UserDTO user)
        {
            string token = "";
            var users = await _context.usuario.ToListAsync();
            var useLog = (from u in users where u.Username == user.Username & u.Password == user.Password select u).ToList();
            if (!useLog.IsNullOrEmpty())
            {
                token = Config.Token.GenerateToken(useLog[0]);
            }
            return new { user = user, token = token };
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool UserExists(int id)
        {
            return _context.usuario.Any(e => e.Id == id);
        }     
    }
}

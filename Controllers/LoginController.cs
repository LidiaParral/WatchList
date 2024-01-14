using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchList_Netflix.Data;
using WatchList_Netflix.Models;

namespace WatchList_Netflix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public IActionResult Login(LoginModel model)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (existingUser == null)
                return NotFound();

            return Ok(existingUser);
        }

        [HttpPost("register")]
        public async Task<IActionResult> SaveUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
    }
}

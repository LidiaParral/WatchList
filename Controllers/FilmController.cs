using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchList_Netflix.Data;
using WatchList_Netflix.Models;

namespace WatchList_Netflix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly DataContext _context;

        public FilmController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Film>>> GetFilms()
        {
            return Ok(await _context.Films.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult<List<Film>>> SaveFilms(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();

            return Ok(await _context.Films.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Film>>> DeleteFilms(int id)
        {
            var dbFilm = await _context.Films.FindAsync(id);
            if (dbFilm == null)
                return BadRequest("Hero not found.");

            _context.Films.Remove(dbFilm);
            await _context.SaveChangesAsync();

            return Ok(await _context.Films.ToListAsync());
        }
    }
}

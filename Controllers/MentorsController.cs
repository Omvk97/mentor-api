using System.Linq;
using System.Threading.Tasks;
using mentor_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mentor_backend.Controllers
{
    [Route("api/mentors")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly DataContext _context;
        public MentorsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMentors()
        {
            var values = await _context.Mentors.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMentor(int id)
        {
            var value = await _context.Mentors.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }
    }
}
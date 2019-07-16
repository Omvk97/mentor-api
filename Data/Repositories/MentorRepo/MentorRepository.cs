using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mentor_api.Models;
using Microsoft.EntityFrameworkCore;

namespace mentor_api.Data.Repositories.MentorRepo
{
    public class MentorRepository : IMentorRepository
    {
        private readonly DataContext _context;
        public MentorRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Mentor>> GetAllMentors()
        {
            var mentors = await _context.Mentors
                .Include(m => m.ProfilePicture)
                .Include(m => m.User)
                .Include(m => m.Price)
                .Include(m => m.TeachableCities).ThenInclude(tc => tc.City)
                .Include(m => m.Teachings)
                .ThenInclude(teach => teach.Category)
                .Include(m => m.Teachings)
                .ThenInclude(teach => teach.TeachingSpecializations)
                .ThenInclude(ts => ts.Specialization)
                .ToListAsync();

            return mentors;
        }

        public async Task<Mentor> GetMentor(int id)
        {
            var mentor = await _context.Mentors
                .Include(m => m.ProfilePicture)
                .Include(m => m.User)
                .Include(m => m.Price)
                .Include(m => m.TeachableCities).ThenInclude(tc => tc.City)
                .Include(m => m.Teachings)
                .ThenInclude(teach => teach.Category)
                .Include(m => m.Teachings)
                .ThenInclude(teach => teach.TeachingSpecializations)
                .ThenInclude(ts => ts.Specialization)
                .FirstOrDefaultAsync(m => m.UserId == id);

            return mentor;
        }

        public async Task<IEnumerable<Mentor>> GetMentors(int categoryId)
        {
            var mentors = await _context.Mentors
                .Where(m => m.Teachings.Any(t => t.CategoryId == categoryId))
                .Include(m => m.ProfilePicture)
                .Include(m => m.User)
                .Include(m => m.Price)
                .Include(m => m.TeachableCities).ThenInclude(tc => tc.City)
                .Include(m => m.Teachings)
                .ThenInclude(teach => teach.Category)
                .Include(m => m.Teachings)
                .ThenInclude(teach => teach.TeachingSpecializations)
                .ThenInclude(ts => ts.Specialization)
                .ToListAsync();

            return mentors;
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
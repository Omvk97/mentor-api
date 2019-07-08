using System.Collections.Generic;
using System.Threading.Tasks;
using mentor_api.Models;
using Microsoft.EntityFrameworkCore;

namespace mentor_api.Data
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

        public async Task<Mentor> GetMentor(int id)
        {
            var mentor = await _context.Mentors
                .Include(m => m.ProfilePicture)
                .Include(m => m.User)
                .Include(m => m.Price)
                .Include(m => m.TeachableCities).ThenInclude(tc => tc.City)
                .Include(m => m.TeachingSpecializations).ThenInclude(ts => ts.Category)
                .Include(m => m.TeachingSpecializations).ThenInclude(ts => ts.Specialization)
                .Include(m => m.PhoneNumbers)
                .FirstOrDefaultAsync(m => m.Id == id);

            return mentor;
        }

        public async Task<IEnumerable<Mentor>> GetMentors()
        {
            var mentors = await _context.Mentors
                .Include(m => m.ProfilePicture)
                .Include(m => m.User)
                .Include(m => m.Price)
                .Include(m => m.TeachableCities).ThenInclude(tc => tc.City)
                .Include(m => m.TeachingSpecializations).ThenInclude(ts => ts.Category)
                .Include(m => m.TeachingSpecializations).ThenInclude(ts => ts.Specialization)
                .Include(m => m.PhoneNumbers)
                .ToListAsync();

            return mentors;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
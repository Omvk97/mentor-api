using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mentor_api.Models.Teachings;
using Microsoft.EntityFrameworkCore;

namespace mentor_api.Data.Repositories.TeachingsRepo
{
    public class TeachingsRepository : ITeachingsRepository
    {
        private readonly DataContext _context;
        public TeachingsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<Specialization>> GetSpecializations(int categoryId)
        {
            var specializations = await _context.Teachings
            .Where(t => t.CategoryId == categoryId)
            .SelectMany(t => t.TeachingSpecializations)
            .Select(t => t.Specialization)
            .Distinct()
            .AsNoTracking()
            .ToListAsync();

            return specializations;
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using mentor_api.Models.Teachings;

namespace mentor_api.Data.Repositories.TeachingsRepo
{
    public interface ITeachingsRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Specialization>> GetSpecializations(int categoryId);
    }
}
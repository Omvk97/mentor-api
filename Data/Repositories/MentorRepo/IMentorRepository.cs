using System.Collections.Generic;
using System.Threading.Tasks;
using mentor_api.Models;

namespace mentor_api.Data.Repositories.MentorRepo
{
    public interface IMentorRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Mentor>> GetAllMentors();
        Task<IEnumerable<Mentor>> GetMentors(int categoryId);
        Task<Mentor> GetMentor(int id);
    }
}
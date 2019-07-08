using System.Collections.Generic;
using System.Threading.Tasks;
using mentor_api.Models;

namespace mentor_api.Data
{
    public interface IMentorRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Mentor>> GetMentors();
        Task<Mentor> GetMentor(int id);
    }
}
using System.Collections.Generic;
using System.Linq;
using mentor_api.Models;
using Newtonsoft.Json;

namespace mentor_api.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/UserDataSeed.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                seedUser(user);
            }

            _context.SaveChanges();
        }

        private void seedUser(User user)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("Password1", out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Name = user.Name.ToLower();
            _context.Users.Add(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public void SeedMentors()
        {
            var mentorData = System.IO.File.ReadAllText("Data/MentorDataSeed.json");
            var mentors = JsonConvert.DeserializeObject<List<Mentor>>(mentorData);
            foreach (var mentor in mentors)
            {
                seedUser(mentor.User);
                checkMentorCities(mentor.TeachableCities);
                checkMentorSpecializations(mentor.TeachingSpecializations);
                _context.Mentors.Add(mentor);
            }
            _context.SaveChanges();
        }

        private void checkMentorCities(ICollection<TeachableCities> cities)
        {
            foreach (var teachableCity in cities)
            {
                var city = teachableCity.City;
                city.Name = city.Name.ToLower();
                var cityInDatabase = _context.Cities.FirstOrDefault(cit => cit.Name == city.Name);
                if (cityInDatabase == null)
                {
                    _context.Cities.Add(city);
                }
                else
                {
                    city.Id = cityInDatabase.Id;
                }
            }
            _context.SaveChanges();
        }

        private void checkMentorSpecializations(ICollection<TeachingSpecialization> specializations)
        {
            foreach (var teachingSpecialization in specializations)
            {
                checkCategory(teachingSpecialization.Category);
                checkSpecialization(teachingSpecialization.Specialization);
            }
            _context.SaveChanges();
        }
        private void checkCategory(Category category)
        {
            category.Name = category.Name.ToLower();

            var categoryInDatabase = _context.Categories.FirstOrDefault(cate => cate.Name == category.Name);
            if (categoryInDatabase == null)
                _context.Categories.Add(category);
            else
                category.Id = categoryInDatabase.Id;
        }
        private void checkSpecialization(Specialization specialization)
        {
            specialization.Name = specialization.Name.ToLower();

            var specializationInDatabase = _context.Specialization.FirstOrDefault(spe => spe.Name == specialization.Name);
            if (specializationInDatabase == null)
                _context.Specialization.Add(specialization);
            else
                specialization.Id = specializationInDatabase.Id;
        }
    }
}
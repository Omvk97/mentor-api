using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using mentor_api.Data.Repositories.MentorRepo;
using mentor_api.DTOs.DetailedDTOs;
using mentor_api.DTOs.ForListDTOs;
using Microsoft.AspNetCore.Mvc;

namespace mentor_api.Controllers
{
    [Route("api/mentors")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorRepository _repo;
        private readonly IMapper _mapper;
        public MentorsController(IMentorRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMentors()
        {
            var mentors = await _repo.GetAllMentors();

            var mentorsToReturn = _mapper.Map<IEnumerable<MentorForListDTO>>(mentors);

            return Ok(mentorsToReturn);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetMentors(int categoryId)
        {
            var mentors = await _repo.GetMentors(categoryId);

            var mentorsToReturn = _mapper.Map<IEnumerable<MentorForListDTO>>(mentors);

            return Ok(mentorsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMentor(int id)
        {
            var mentor = await _repo.GetMentor(id);

            var mentorToReturn = _mapper.Map<MentorForDetailedDTO>(mentor);

            return Ok(mentorToReturn);
        }
    }
}
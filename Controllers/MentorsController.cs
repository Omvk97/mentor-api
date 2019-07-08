using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using mentor_api.Data;
using mentor_api.DTOs.DetailedDTOs;
using mentor_api.DTOs.ForListDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mentor_api.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetMentors()
        {
            var mentors = await _repo.GetMentors();

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
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using mentor_api.Data.Repositories.TeachingsRepo;
using mentor_api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace mentor_api.Controllers
{
    [Route("api/teachings")]
    [ApiController]
    public class TeachingsController : ControllerBase
    {
        private readonly ITeachingsRepository _repo;
        private readonly IMapper _mapper;
        public TeachingsController(ITeachingsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.GetCategories();
            return Ok(categories);
        }

        [HttpGet("specializations/{categoryId}")]
        public async Task<IActionResult> GetSpecializations(int categoryId)
        {
            var specializations = await _repo.GetSpecializations(categoryId);

            var specializationsToReturn = _mapper.Map<IEnumerable<SpecializationDTO>>(specializations);

            return Ok(specializationsToReturn);
        }
    }
}
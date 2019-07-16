using System.Linq;
using AutoMapper;
using mentor_api.DTOs;
using mentor_api.DTOs.DetailedDTOs;
using mentor_api.DTOs.ForListDTOs;
using mentor_api.Models;
using mentor_api.Models.Teachings;

namespace mentor_api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDTO>();
            CreateMap<User, UserForListDTO>();
            CreateMap<Price, PriceForDetailedDTO>();
            CreateMap<Price, PriceForListDTO>();
            CreateMap<TeachableCities, TeachableCitiesDTO>();
            CreateMap<Specialization, SpecializationDTO>();
            CreateMap<Teaching, TeachingDTO>()
                .ForMember(dest => dest.Specializations, opt =>
                {
                    opt.MapFrom(src => src.TeachingSpecializations.Select(s => s.Specialization).ToList());
                });
            CreateMap<Mentor, MentorForListDTO>();
            CreateMap<Mentor, MentorForDetailedDTO>();
        }
    }
}
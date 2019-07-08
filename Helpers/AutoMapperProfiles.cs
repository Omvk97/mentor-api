using System.Linq;
using AutoMapper;
using mentor_api.DTOs.DetailedDTOs;
using mentor_api.DTOs.ForListDTOs;
using mentor_api.Models;

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
            CreateMap<TeachingSpecialization, TeachingSpecializationDTO>();
            CreateMap<Mentor, MentorForListDTO>();
            CreateMap<Mentor, MentorForDetailedDTO>()
                .ForMember(dest => dest.PhoneNumbers, opt =>
                {
                    opt.MapFrom(src => src.PhoneNumbers.Select(p => p.PhoneNumber).ToList());
                });
        }
    }
}
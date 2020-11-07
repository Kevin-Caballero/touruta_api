using AutoMapper;
using Touruta.Core.DTOs;
using Touruta.Core.Entities;

namespace Touruta.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Tour, TourDto>();
            CreateMap<TourDto, Tour>();
        }
    }
}

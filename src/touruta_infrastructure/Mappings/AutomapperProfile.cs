using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using Touruta.Core.Data;
using Touruta.Core.DTOs;

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

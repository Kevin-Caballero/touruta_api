using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Touruta.Core.Data;
using Touruta.Core.DTOs;
using Touruta.Core.Interfaces;
using Touruta.Infrastructure.Repositories;

namespace Touruta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;

        public ToursController(ITourRepository tourRepository, IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTours()
        {
            var tours = await _tourRepository.GetTours();
            var toursDto = _mapper.Map<IEnumerable<TourDto>>(tours);
            return Ok(toursDto);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTour(int id)
        {
            var tour = await _tourRepository.GetTour(id);
            var tourDto = _mapper.Map<TourDto>(tour);
            return Ok(tourDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostTour(TourDto tourDto)
        {
            var tour = _mapper.Map<Tour>(tourDto);
            await _tourRepository.PostTour(tour);
            return Ok(tour);
        }
    }
}

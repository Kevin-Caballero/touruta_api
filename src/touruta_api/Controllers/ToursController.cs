using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Api.Responses;
using Touruta.Core.DTOs;
using Touruta.Core.Entities;
using Touruta.Core.Interfaces;

namespace Touruta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;

        public ToursController(ITourService tourService, IMapper mapper)
        {
            _tourService = tourService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTours()
        {
            var tours = await _tourService.GetTours();
            var toursDto = _mapper.Map<IEnumerable<TourDto>>(tours);
            var response = new ApiResponse<IEnumerable<TourDto>>(toursDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTour(int id)
        {
            var tour = await _tourService.GetTour(id);
            var tourDto = _mapper.Map<TourDto>(tour);
            var response = new ApiResponse<TourDto>(tourDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostTour(TourDto tourDto)
        {
            var tour = _mapper.Map<Tour>(tourDto);
            await _tourService.PostTour(tour);
            tourDto = _mapper.Map<TourDto>(tour);
            var response = new ApiResponse<TourDto>(tourDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, TourDto tourDto)
        {
            var tour = _mapper.Map<Tour>(tourDto);
            tour.IdTour = id;

            var result = await _tourService.PutTour(tour);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            var result = await _tourService.DeleteTour(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}

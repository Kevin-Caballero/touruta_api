﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Touruta.Core.Data;
using Touruta.Core.Interfaces;
using Touruta.Infrastructure.Repositories;

namespace Touruta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ITourRepository _tourRepository;
        public ToursController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTours()
        {
            var tours = await _tourRepository.GetTours();
            return Ok(tours);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTour(int id)
        {
            var tour = await _tourRepository.GetTour(id);
            return Ok(tour);
        }

        [HttpPost]
        public async Task<IActionResult> PostTour(Tour tour)
        {
            await _tourRepository.PostTour(tour);
            return Ok(tour);
        }
    }
}

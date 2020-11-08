using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Touruta.Api.Responses;
using Touruta.Core.CustomEntities;
using Touruta.Core.DTOs;
using Touruta.Core.Entities;
using Touruta.Core.Interfaces;
using Touruta.Core.QueryFilters;
using Touruta.Infrastructure.Interfaces;

namespace Touruta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ToursController(ITourService tourService, IMapper mapper, IUriService uriService)
        {
            _tourService = tourService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(GetTours))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetTours([FromQuery]TourQueryFilter filters)
        {
            var tours = _tourService.GetTours(filters);
            var toursDto = _mapper.Map<IEnumerable<TourDto>>(tours);

            var metadata = new Metadata
            {
                TotalCount = tours.TotalCount,
                PageSize= tours.PageSize,
                CurrentPage= tours.CurrentPage,
                TotalPages= tours.TotalPages,
                HasNextPage = tours.HasNextPage,
                HasPreviousPage = tours.HasPreviousPage,
                NexPageUrl = _uriService.GetTourPaginationUri(filters, Url.RouteUrl(nameof(GetTours))).ToString(),
                PreviousPageUrl = _uriService.GetTourPaginationUri(filters, Url.RouteUrl(nameof(GetTours))).ToString()
            };
            var response = new ApiResponse<IEnumerable<TourDto>>(toursDto)
            {
                Meta = metadata
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            
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
            tour.Id = id;

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

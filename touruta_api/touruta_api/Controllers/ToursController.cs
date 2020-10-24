using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
    }
}

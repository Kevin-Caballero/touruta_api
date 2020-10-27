using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.Entities;
using Touruta.Core.Interfaces;

namespace Touruta.Core.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IUserRepository _userRepository; 
        
        public TourService(ITourRepository tourRepository, IUserRepository userRepository)
        {
            _tourRepository = tourRepository;
            _userRepository = userRepository;
        }
        
        public async Task<IEnumerable<Tour>> GetTours()
        {
            return await _tourRepository.GetTours();
        }

        public async Task<Tour> GetTour(int id)
        {
            return await _tourRepository.GetTour(id);
        }

        public async Task PostTour(Tour tour)
        {
            var user = await _userRepository.GetUser(tour.IdUser);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            if (tour.Description.ToUpper().Contains("SEXO"))
            {
                throw new Exception("Content not allowed");
            }
            await _tourRepository.PostTour(tour);
        }

        public async Task<bool> PutTour(Tour tour)
        {
            return await _tourRepository.PutTour(tour);
        }

        public async Task<bool> DeleteTour(int id)
        {
            return await _tourRepository.DeleteTour(id);
        }
    }
}
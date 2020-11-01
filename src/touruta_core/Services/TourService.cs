using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.Entities;
using Touruta.Core.Interfaces;

namespace Touruta.Core.Services
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TourService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Tour>> GetTours()
        {
            return await _unitOfWork.TourRepository.GetAll();
        }

        public async Task<Tour> GetTour(int id)
        {
            return await _unitOfWork.TourRepository.GetById(id);
        }

        public async Task PostTour(Tour tour)
        {
            var user = await _unitOfWork.UserRepository.GetById(tour.IdUser);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            if (tour.Description.ToUpper().Contains("SEXO"))
            {
                throw new Exception("Content not allowed");
            }
            await _unitOfWork.TourRepository.Add(tour);
        }

        public async Task<bool> PutTour(Tour tour)
        {
            await _unitOfWork.TourRepository.Update(tour);
            return true;
        }

        public async Task<bool> DeleteTour(int id)
        {
            await _unitOfWork.TourRepository.Delete(id);
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Touruta.Core.CustomEntities;
using Touruta.Core.Entities;
using Touruta.Core.Exceptions;
using Touruta.Core.Interfaces;
using Touruta.Core.QueryFilters;

namespace Touruta.Core.Services
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        
        public TourService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        
        public PagedList<Tour> GetTours(TourQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize; 
            
            var tours = _unitOfWork.TourRepository.GetAll();
            if (filters.UserId != null)
            {
                tours = tours.Where(x => x.IdUser == filters.UserId);
            }
            if (filters.Date != null)
            {
                tours = tours.Where(x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }
            if (filters.Description != null)
            {
                tours = tours.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            var pagegTours = PagedList<Tour>.Create(tours, filters.PageNumber, filters.PageSize);

            return pagegTours;
        }

        public async Task<Tour> GetTour(int id)
        {
            return await _unitOfWork.TourRepository.GetById(id);
        }

        public async Task PostTour(Tour tour)
        {
            //Validar que el usuario exista
            var user = await _unitOfWork.UserRepository.GetById(tour.IdUser);
            if (user == null)
            {
                throw new BusinessException("User does not exist");
            }

            //Si el usuario tiene menos de 10 tours publicados validamos la fehca para dejarle publicar uno a la semana
            var userTours = await _unitOfWork.TourRepository.GetToursByUser(tour.IdUser);
            if (userTours.Count() < 10)
            {
                var lastTour = userTours.OrderByDescending(x => x.Date).FirstOrDefault();
                if ((DateTime.Now - lastTour.Date).TotalDays < 7)
                {
                    throw new BusinessException($"You are not able to publish untill {Math.Round(7.0 - (DateTime.Now - lastTour.Date).TotalDays)} days passed");
                }
            }
            
            //Se lanza una excepcion se en la descripcion se incluye la palabra sexo
            //TODO: mejorar filtro contenido inadecuado
            if (tour.Description.ToUpper().Contains("SEXO"))
            {
                throw new BusinessException("Content not allowed");
            }
            await _unitOfWork.TourRepository.Add(tour);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutTour(Tour tour)
        {
            _unitOfWork.TourRepository.Update(tour);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTour(int id)
        {
            await _unitOfWork.TourRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
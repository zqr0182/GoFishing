using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoFishing.Domain;
using GoFishing.Domain.Models;
using GoFishing.Repository;

namespace GoFishing.Application.Services
{
    public interface IFishingService
    {
        List<Trip> GetTrips();

        Trip GetTripDetail(int id);
    }

    public class FishingService : IFishingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FishingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Trip> GetTrips()
        {

            return _unitOfWork.Trips.MatcheAll().ToList();
        }

        public Trip GetTripDetail(int id)
        {
            return _unitOfWork.Trips.MatcheById(id);
        }
    }
}

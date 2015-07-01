using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoFishing.Domain.Models;

namespace GoFishing.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Trip> Trips { get; }
        IRepository<Trophy> Trophies { get; }
        void Commit();
    }

    public class GoFishingUnitOfWork : IUnitOfWork
    {
        private readonly GoFishingContext _context;

        public IRepository<Trip> Trips { get; private set; }
        public IRepository<Trophy> Trophies { get; private set; }

        public GoFishingUnitOfWork(GoFishingContext context, IRepository<Trip> tripRepository, IRepository<Trophy> trophyRepository)
        {
            _context = context;
            Trips = tripRepository;
            Trophies = trophyRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}

using Domain.Contacts;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TripRepo: ITripRepo
    {
        private readonly ApplicationDbContext _appDbContext;

        public TripRepo(ApplicationDbContext appDbContext) //accessing to appDbContext
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TripDb> AllTrip
        {
            get
            {
                return _appDbContext.Trip;
            }
        }
    }
}

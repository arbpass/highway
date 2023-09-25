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
    public class SeatsRepo: ISeatsRepo
    {
        private readonly ApplicationDbContext _appDbContext;

        public SeatsRepo(ApplicationDbContext appDbContext) //accessing to appDbContext
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SeatsDb> AllSeats
        {
            get
            {
                return _appDbContext.Seats;
            }
        }
    }
}

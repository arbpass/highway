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
    public class CityRepo: ICityRepo
    {
        private readonly ApplicationDbContext _appDbContext;

        public CityRepo(ApplicationDbContext appDbContext) //accessing to appDbContext
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<CityDb> AllCity
        {
            get
            {
                return _appDbContext.City;
            }
        }
    }
}

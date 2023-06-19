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
    public class BusRepo: IBusRepo
    {
        private readonly ApplicationDbContext _appDbContext;

        public BusRepo(ApplicationDbContext appDbContext) //accessing to appDbContext
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<BusDb> AllBus
        {
            get
            {
                return _appDbContext.Bus;
            }
        }
    }
}

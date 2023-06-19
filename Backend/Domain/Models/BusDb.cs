using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BusDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Number { get; set; }
        public string Route { get; set; }
        public int PricePerKm { get; set; }
        public int SpeedPerKm { get; set; }
        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CityDb
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int PinCode { get; set; }
    }
}

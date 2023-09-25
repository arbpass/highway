using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Extra
{
    public class BookingModel
    {
        public string busName { get; set; }
        public string busCompany{ get; set; }
        public string seatNo { get; set; }
        public string date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TripDb
    {
        public int Id { get; set; }
        public string Bus { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }
    }
}

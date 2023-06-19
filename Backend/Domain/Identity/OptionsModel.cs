using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Identity
{
    public class OptionsModel
    {
        [Required(ErrorMessage = "From is required")]
        public string? City1 { get; set; }

        [Required(ErrorMessage = "To is required")]
        public string? City2 { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string? Date { get; set; }
    }
}

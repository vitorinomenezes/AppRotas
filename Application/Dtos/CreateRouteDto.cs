using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CreateRouteDto
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Origin { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Destination { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Value { get; set; }
    }
}

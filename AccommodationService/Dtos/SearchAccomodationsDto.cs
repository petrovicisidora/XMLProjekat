using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AccommodationService.Dtos
{
    public class SearchAccomodationsDto
    {
        [Required]
        public string Location { get; set; }
        [Required]
        public int GuestNumber { get; set; }
        [Required]
        public DateTime? Start { get; set; }
        [Required]
        public DateTime? End { get; set; }
    }
}

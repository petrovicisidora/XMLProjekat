using System;
using System.ComponentModel.DataAnnotations;

namespace SystemService.Dtos
{
    public class SearchReservationsDto
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

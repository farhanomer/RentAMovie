using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.DTO
{
    public class MovieRentDTO
    {
        public int Id { get; set; }
        [Required]
        public decimal DailyRent { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime ValueDate { get; set; }
        [Required]
        public int MovieId { get; set; }
        public MovieDTO Movie { get; set; }
        public List<MovieRentalDTO> MovieRentals { get; set; }
    }
}

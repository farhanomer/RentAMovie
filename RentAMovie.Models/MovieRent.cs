using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models
{
    public class MovieRent 
    {
        public int Id { get; set; }
        public decimal DailyRent { get; set; }
        public bool Active { get; set; }
        public DateTime ValueDate { get; set; } = DateTime.Now;
        public Movie Movie { get; set; }
        public List<MovieRental> MovieRentals { get; set; }

    }
}

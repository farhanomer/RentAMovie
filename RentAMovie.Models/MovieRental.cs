using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models
{
    public class MovieRental 
    {
        public int Id { get; set; }
        public DateTime RentedDate { get; set; }= DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public bool Returned { get; set; } = false;
        public Member Member { get; set; }
        public MovieCopy MovieCopy { get; set; }

    }
}

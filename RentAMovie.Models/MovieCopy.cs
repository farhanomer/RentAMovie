using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models
{
    public class MovieCopy 
    { 
        public int Id { get; set; }
        public Guid MovieTagNumber { get; set; }
        public bool IsDamaged { get; set; } = false;
        public Movie Movie { get; set; }

    }
}

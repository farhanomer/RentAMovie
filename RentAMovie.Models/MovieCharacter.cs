using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models
{
    public class MovieCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MovieRole MovieRole { get; set; }
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }

    }
}

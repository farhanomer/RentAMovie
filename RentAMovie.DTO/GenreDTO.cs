using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.DTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieDTO> Movies { get; set; }
    }
    public class GenreOnlyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

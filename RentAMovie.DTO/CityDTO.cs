using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovieDTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MemberDTO> Members { get; set; }
    }
}

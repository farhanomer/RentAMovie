using RentAMovieDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.DTO
{
    public class MovieRentalDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime RentedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Returned { get; set; } = false;
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int MovieCopyId { get; set; }
        public MemberDTO Member { get; set; }
        public MovieCopyDTO MovieCopy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.DTO
{
    public class MovieCharacterDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MovieRoleId { get; set; }
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int MovieId { get; set; }
        public MovieRoleDTO MovieRole { get; set; }
        public ActorDTO Actor { get; set; }
        public MovieDTO Movie { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models
{
    public class Actor 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName ="text")]
        public string Summary { get; set; }
        [Column(TypeName ="text")]
        public string BioDetails { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime? DateofDeath { get; set; }
        public ICollection<MovieCharacter> MovieCharacters { get; set; }

    }
}

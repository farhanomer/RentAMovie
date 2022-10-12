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
        public int MovieRoleId { get; set; }
        public virtual MovieRole MovieRole { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

    }
}

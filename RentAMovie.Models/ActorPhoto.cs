using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models
{
    public class ActorPhoto
    {
        public int Id { get; set; }
        public bool IsDefaultPhoto { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Actor Actor { get; set; }
        public ImageGallery Gallery { get; set; }

    }
}

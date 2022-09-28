using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.Models
{
    public class MoviePhoto 
    {
        public int Id { get; set; }
        public bool IsDefaultPhoto { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Movie Movie { get; set; }
        public ImageGallery Gallery { get; set; }

    }
}

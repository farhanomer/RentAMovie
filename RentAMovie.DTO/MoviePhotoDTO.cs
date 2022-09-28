using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovieDTO
{
    public class MoviePhotoDTO
    {
        public int Id { get; set; }
        [Required]
        public bool IsDefaultPhoto { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int GalleryId { get; set; }
        public MovieDTO Movie { get; set; }
        public ImageGalleryDTO Gallery { get; set; }
    }
}

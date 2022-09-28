using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovieDTO
{
    public class ActorPhotoDTO 
    {
        public int Id { get; set; }
        public bool IsDefaultPhoto { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int GalleryId { get; set; }
        public ActorDTO Actor { get; set; }
        public ImageGalleryDTO Gallery { get; set; }
    }
}

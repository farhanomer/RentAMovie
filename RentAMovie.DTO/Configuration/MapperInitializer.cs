using AutoMapper;
using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.DTO.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorPhoto, ActorPhotoDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Genre, GenreOnlyDTO>().ReverseMap();
            CreateMap<ImageGallery, ImageGalleryDTO>().ReverseMap();
            CreateMap<MemberCreditCard, MemberCreditCardDTO>().ReverseMap();
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Member, RegisterDTO>().ReverseMap();
            CreateMap<Member, SignInDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Movie, MovieOnlyDTO>().ReverseMap();
            CreateMap<MovieCharacter, MovieCharacterDTO>().ReverseMap();
            CreateMap<MovieCopy, MovieCopyDTO>().ReverseMap();
            CreateMap<MoviePhoto, MoviePhotoDTO>().ReverseMap();
            CreateMap<MovieRent, MovieRentDTO>().ReverseMap();
            CreateMap<MovieRental, MovieRentalDTO>().ReverseMap();
            CreateMap<MovieRole, MovieRoleDTO>().ReverseMap();
        }
    }
}

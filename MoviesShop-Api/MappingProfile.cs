using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Models;
using Movies.Dtos;

namespace MoviesShopApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          CreateMap<Customer, CustomerDto>();
            
            CreateMap<Movie, MovieDto>();

            CreateMap<MembershipType, MembershipTypeDto>();
          CreateMap<Genre, GenreDto>();
            CreateMap<Game, GameDto>();
            CreateMap<AudioBook, AudioBookDto>();


            // Dto to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>()
              .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<GameDto, Game>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<AudioBookDto, AudioBook>().ForMember(c => c.Id, opt => opt.Ignore());



        }

    }
}

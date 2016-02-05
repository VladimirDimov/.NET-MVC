using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;
using MoviesInfo.Models;
using MoviesInfo.Models.Movies;

namespace MoviesInfo.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Movie, AllMoviesModel>();
        }
    }
}
using System;
using ApiEntityDapper.API.Model;
using ApiEntityDapper.Domain.Entities;
using AutoMapper;

namespace ApiEntityDapper.API.Mappers
{
	public class EntityToViewModelMapping : Profile
	{
		public EntityToViewModelMapping()
		{
			CreateMap<Movie, MovieViewModel>().ReverseMap();
			CreateMap<MovieCategory, MovieCategoryViewModel>().ReverseMap();
		}
	}
}


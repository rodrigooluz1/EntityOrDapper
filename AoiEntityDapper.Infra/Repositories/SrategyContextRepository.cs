using System;
using ApiEntityDapper.Domain.Entities;
using ApiEntityDapper.Domain.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApiEntityDapper.Infra.Repositories
{
	public class StrategyContextRepository 
    {
		private IMovieStrategyRepository _imovierepository;

		public StrategyContextRepository(IMovieStrategyRepository imovierepository)
		{
			_imovierepository = imovierepository;
		}

		public void DefineEstrategy(IMovieStrategyRepository imovierepository)
		{
            _imovierepository = imovierepository;
        }

        public async Task<List<Movie>> ListMovies() => await _imovierepository.ListMovies();

        public async Task<Movie> GetMovieById(string Id) => await _imovierepository.GetMovieById(Id);

        public async Task<bool> UpdateMovie(Movie movie) => await _imovierepository.UpdateMovie(movie);

        public async Task<Movie> CreateMovie(Movie movie) => await _imovierepository.CreateMovie(movie);

        public async Task<bool> DeleteMovie(string Id) => await _imovierepository.DeleteMovie(Id);

    }
}


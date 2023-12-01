using System;
using ApiEntityDapper.Domain.Entities;

namespace ApiEntityDapper.Domain.Interface.IRepositories
{
	public interface IMovieStrategyRepository
	{
		Task<List<Movie>> ListMovies();

		Task<Movie> GetMovieById(string Id);

		Task<Movie> CreateMovie(Movie movie);

		Task<bool> UpdateMovie(Movie movie);

		Task<bool> DeleteMovie(string Id);

	}
}


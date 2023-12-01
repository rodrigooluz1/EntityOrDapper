using ApiEntityDapper.Domain.Entities;

namespace ApiEntityDapper.Domain.Interface.IServices
{
	public interface IMovieService
	{
        Task<List<Movie>> ListMovies(string type);

        Task<Movie> GetMovieById(string Id, string type);

        Task<Movie> CreateMovie(Movie movie, string type);

        Task<bool> UpdateMovie(Movie movie, string type);

        Task<bool> DeleteMovie(string Id, string type);
    }
}


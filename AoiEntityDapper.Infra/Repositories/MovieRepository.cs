using System;
using ApiEntityDapper.Domain.Entities;
using ApiEntityDapper.Domain.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApiEntityDapper.Infra.Repositories
{
	public class MovieRepository : IMovieStrategyRepository
    {
        private readonly ApiEntityContext _context;

        public MovieRepository(ApiEntityContext context)
		{
            _context = context;

        }

        public async Task<List<Movie>> ListMovies()
        {
            return await _context.Set<Movie>().Where(m => m.Deleted != true).ToListAsync();
        }

        public async Task<Movie> GetMovieById(string Id)
        {
            try
            {
                return await _context.Set<Movie>().Where(m => m.Id.ToString() == Id && m.Deleted != true).FirstAsync();

            }
            catch
            {
                return null;
            }
            
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {

            _context.Set<Movie>().Update(movie);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            _context.Set<Movie>().Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<bool> DeleteMovie(string Id)
        {
            var movie = await _context.Set<Movie>().Where(m => m.Id.ToString() == Id).FirstOrDefaultAsync();

            movie.Deleted = true;

            if (movie is null)
                return false;
            else
            {
                //_context.Set<Movie>().Remove(movie);
                _context.Set<Movie>().Update(movie);

                await _context.SaveChangesAsync();

                return true;
            }
            
        }
        
    }
}


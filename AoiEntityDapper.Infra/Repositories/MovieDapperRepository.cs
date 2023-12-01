using System;
using System.Security.Cryptography;
using ApiEntityDapper.Domain.Entities;
using ApiEntityDapper.Domain.Interface.IRepositories;
using Dapper;

namespace ApiEntityDapper.Infra.Repositories
{
	public class MovieDapperRepository : IMovieStrategyRepository
    {
        private readonly ApiDapperContext _context;

        public MovieDapperRepository(ApiDapperContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> ListMovies()
        {
            using (var conn = _context.Connection)
            {
                string query = "SELECT* FROM movie";
                List<Movie> movies = (await conn.QueryAsync<Movie>(sql: query)).ToList();
                return movies;
            }
        }

        public async Task<Movie> GetMovieById(string Id)
        {
            using (var conn = _context.Connection)
            {
                string query = "SELECT* FROM movie WHERE Id = @Id";
                Movie movie = (await conn.QueryFirstOrDefaultAsync<Movie>(sql: query, param: new { Id }));
                return movie;
            }
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();

            using (var conn = _context.Connection)
            {
                string command = @"INSERT INTO movie (Id, Title, Description, Year, IdCategory, Deleted)
                                VALUES(@Id, @Title, @Description, @Year, @IdCategory, @Deleted)";

                var result = (await conn.ExecuteAsync(sql: command, param: movie));

                return movie;
            }

        }

        public async Task<bool> UpdateMovie(Movie movie)
        {

            using (var conn = _context.Connection)
            {
                string command = @"UPDATE movie 
                                SET Title = @Title, Description = @Description, Year = @Year, IdCategory = @IdCategory
                                WHERE Id = @Id";

                var result = (await conn.ExecuteAsync(sql: command, param: movie));

                return true;
            }

        }

        public async Task<bool> DeleteMovie(string Id)
        {
            using (var conn = _context.Connection)
            {
                string command = @"UPDATE movie
                                SET Deleted = 1 WHERE Id = @Id";

                var result = (await conn.ExecuteAsync(sql: command, param: new { Id }));

                return true;
            }
        }
        
    }
}


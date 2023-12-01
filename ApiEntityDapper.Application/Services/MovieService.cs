using System;
using ApiEntityDapper.Domain.Entities;
using ApiEntityDapper.Domain.Interface.IRepositories;
using ApiEntityDapper.Domain.Interface.IServices;
using ApiEntityDapper.Infra;
using ApiEntityDapper.Infra.Repositories;

namespace ApiEntityDapper.Application.Services
{
	public class MovieService : IMovieService
	{
        private readonly ApiEntityContext _context;
        private readonly ApiDapperContext _contextDapper;

        public MovieService(ApiEntityContext context, ApiDapperContext contextDapper)
		{
           _context = context;
            _contextDapper = contextDapper;
        }

        private StrategyContextRepository DefineRepository(string type)
        {
            var ctx = new StrategyContextRepository(new MovieRepository(_context));

            if (type != "entity")
                ctx.DefineEstrategy(new MovieDapperRepository(_contextDapper));

            return ctx;
        }

        public async Task<List<Movie>> ListMovies(string type)
        {
            var ctx = DefineRepository(type);

            return await ctx.ListMovies();
        }

        public async Task<Movie> GetMovieById(string Id, string type)
        {
            var ctx = DefineRepository(type);

            return await ctx.GetMovieById(Id);
        }

        public async Task<Movie> CreateMovie(Movie movie, string type)
        {
            var ctx = DefineRepository(type);

            return await ctx.CreateMovie(movie);
        }

        public async Task<bool> UpdateMovie(Movie movie, string type)
        {
            var ctx = DefineRepository(type);

            return await ctx.UpdateMovie(movie);
        }

        public async Task<bool> DeleteMovie(string Id, string type)
        {
            var ctx = DefineRepository(type);

            return await ctx.DeleteMovie(Id);
        }
        
    }
}


using System;
using ApiEntityDapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEntityDapper.Infra
{
	public class ApiEntityContext : DbContext
	{
		public ApiEntityContext()
		{
		}

		DbSet<Movie> movie { get; set; }
        DbSet<MovieCategory> movieCategory { get; set; }

        public ApiEntityContext(DbContextOptions<ApiEntityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiEntityContext).Assembly);
        }
    }
}


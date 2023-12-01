using System;
using ApiEntityDapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEntityDapper.Infra.Mapping
{
	public class MovieMapping : IEntityTypeConfiguration<Movie>
	{ 
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title).HasColumnType("varchar(129)");

            builder.Property(m => m.Description).HasColumnType("varchar(258)");

            builder.Property(m => m.Year);

            builder.HasOne(m => m.MovieCategory)
            .WithMany()  // ou .WithOne(), dependendo do lado do relacionamento
            .HasForeignKey(m => m.IdCategory);

            builder.Property(m => m.Deleted);

            builder.ToTable("movie");
        }
    }
}


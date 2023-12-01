using System;
using ApiEntityDapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEntityDapper.Infra.Mapping
{
    public class MovieCategoryMapping : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.HasKey(c => c.IdCategory);

            builder.Property(c => c.Description).HasColumnType("varchar(100)");

            builder.Property(c => c.Deleted);

            builder.ToTable("MovieCategoryB");
        }
    }
}


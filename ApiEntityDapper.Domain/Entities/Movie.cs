using System;
using System.Text.Json.Serialization;

namespace ApiEntityDapper.Domain.Entities
{
	public class Movie
	{
        public Movie(Guid id, string title, string description, int year, int idCategory, bool deleted)
        {
            Id = id;
            Title = title;
            Description = description;
            Year = year;
            IdCategory = idCategory;
            Deleted = deleted;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int IdCategory { get; set; }
        [JsonIgnore]
        public MovieCategory MovieCategory { get; set; }
        public bool Deleted { get; set; }
    }
}


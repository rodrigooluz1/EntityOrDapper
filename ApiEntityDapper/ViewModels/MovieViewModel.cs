using System;
namespace ApiEntityDapper.API.Model
{
	public class MovieViewModel
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Year { get; set; }
		public int IdCategory { get; set; }
	}
}


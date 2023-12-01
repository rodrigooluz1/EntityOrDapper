using System;
namespace ApiEntityDapper.Domain.Entities
{
	public class MovieCategory
	{
        public int IdCategory { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
    }
}


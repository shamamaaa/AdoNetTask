using System;
namespace ADONETtask.Models
{
	public class Music
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public int ArtistId { get; set; }
    }
}


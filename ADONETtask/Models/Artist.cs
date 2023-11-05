using System;
using System.ComponentModel;

namespace ADONETtask.Models
{
	public class Artist
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}


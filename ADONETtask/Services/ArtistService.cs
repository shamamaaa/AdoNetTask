using System;
using ADONETtask.Data;
using ADONETtask.Models;
using System.Data;

namespace ADONETtask.Services
{
	public class ArtistService
	{
        private AzureSql _database = new AzureSql();

        public void CreateArtist(Artist artist)
        {
            string cmd = $"INSERT INTO Artists VALUES('{artist.Name}','{artist.Surname}','{artist.Gender}','{artist.Birthday}'";
            int result = _database.ExecuteCommand(cmd);
            if (result > 0)
            {
                Console.WriteLine("Command successfully completed");
            }
            else
            {
                Console.WriteLine("Error occured");
            }
        }

        public List<Artist> GetAllArtists()
        {
            string query = "SELECT * FROM Artists";
            DataTable table = _database.ExecuteQuery(query);

            List<Artist> artists = new List<Artist>();

            foreach (DataRow row in table.Rows)
            {
                Artist artist = new Artist
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Birthday = DateTime.Parse(row["Birthday"].ToString())
                };

                artists.Add(artist);
            }
            return artists;
        }


        public void DeleteArtist(int id)
        {
            string cmd = $"DELETE FROM Artists WHERE Id={id}";
            _database.ExecuteCommand(cmd);
        }

        public Artist GetArtistById(int id)
        {
            string query = $"SELECT * FROM Artists WHERE Id={id}";
            DataTable table = _database.ExecuteQuery(query);

            if (table.Rows.Count > 0)
            {
                Artist artist = new Artist
                {
                    Id = (int)table.Rows[0]["Id"],
                    Name = table.Rows[0]["Name"].ToString(),
                    Surname = table.Rows[0]["Surname"].ToString(),
                    Gender = table.Rows[0]["Gender"].ToString(),
                    Birthday = DateTime.Parse(table.Rows[0]["Birthday"].ToString())
                };

                return artist;

            }
            else
            {
                throw new Exception("Artist not found.");
            }
        }
    }
}


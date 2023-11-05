using System;
using System.Data;
using ADONETtask.Data;
using ADONETtask.Models;

namespace ADONETtask.Services
{
	internal class MusicService
	{
        private AzureSql _database = new AzureSql();

        public void CreateMusic(Music music)
        {
            string cmd = $"INSERT INTO Musics VALUES('{music.Name}','{music.Duration}','{music.CategoryId}','{music.ArtistId}'";
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

        public List<Music> GetAllMusics()
        {
            string query = "SELECT * FROM Musics";
            DataTable table = _database.ExecuteQuery(query);

            List<Music> musics = new List<Music>();

            foreach (DataRow row in table.Rows)
            {
                Music music = new Music
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Duration = (int)row["Duration"],
                    CategoryId = (int)row["CategoryId"],
                    ArtistId= (int)row["ArtistId"],
                };

                musics.Add(music);
            }
            return musics;
        }


        public void DeleteMusic(int id)
        {
            string cmd = $"DELETE FROM Musics WHERE Id={id}";
            _database.ExecuteCommand(cmd);
        }

        public Music GetMusicById(int id)
        {
            string query = $"SELECT * FROM Musics WHERE Id={id}";
            DataTable table = _database.ExecuteQuery(query);

            if (table.Rows.Count > 0)
            {
                Music music = new Music
                {
                    Id = (int)table.Rows[0]["Id"],
                    Name = table.Rows[0]["Name"].ToString(),
                    Duration = (int)table.Rows[0]["Duration"],
                    CategoryId = (int)table.Rows[0]["CategoryId"],
                    ArtistId = (int)table.Rows[0]["ArtistId"],
                };

                return music;

            }
            else
            {
                throw new Exception("Music not found.");
            }
        }

    }
}


using ADONETtask.Models;
using ADONETtask.Services;

namespace ADONETtask;

class Program
{
    static void Main(string[] args)
    {
        MusicService musicService = new MusicService();
        ArtistService artistService = new ArtistService();

        Artist artist = new Artist
        {
            Name = "Shamama",
            Surname = "Guliyeva",
            Gender = "Female",
            Birthday = DateTime.Now
        };

        Artist artist1 = new Artist
        {
            Name = "Zuzu",
            Surname = "Gurbanova",
            Gender = "Female",
            Birthday = DateTime.Now
        };

        Artist artist2 = new Artist
        {
            Name = "Nihat",
            Surname = "Unutdum",
            Gender = "Male",
            Birthday = DateTime.Now
        };

        artistService.CreateArtist(artist);
        artistService.CreateArtist(artist1);
        artistService.CreateArtist(artist2);


        Music music = new Music
        {
            Name = "Yeto",
            Duration = 120,
            CategoryId = 1,
            ArtistId = 1
        };
        musicService.CreateMusic(music);

        Music music1 = new Music
        {
            Name = "Masya",
            Duration = 140,
            CategoryId = 3,
            ArtistId = 2
        };
        musicService.CreateMusic(music1);

        Music music2 = new Music
        {
            Name = "Sinanay",
            Duration = 240,
            CategoryId = 2,
            ArtistId = 1
        };
        musicService.CreateMusic(music2);

        //musicService.DeleteMusic(2);
        //artistService.DeleteArtist(3);


        List<Artist> artists = artistService.GetAllArtists();
        Console.WriteLine("Artist:");
        foreach (Artist item in artists)
        {
            Console.WriteLine($"{item.Name} {item.Surname}");
        }

        List<Music> musics = musicService.GetAllMusics();
        Console.WriteLine("Musics");
        foreach (Music item in musics)
        {
            Console.WriteLine($"{item.Name}");
        }

        Music idmusic = musicService.GetMusicById(3);
        Console.WriteLine(idmusic.Name);

        Artist idartist = artistService.GetArtistById(2);
        Console.WriteLine($"{idartist.Name} {idartist.Surname}");
    }
}


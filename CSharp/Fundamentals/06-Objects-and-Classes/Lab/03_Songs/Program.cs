using System.Security.Cryptography.X509Certificates;

namespace _03_Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {                
                string[] songInfo = Console.ReadLine().Split("_").ToArray();
                string typeList = songInfo[0];
                string name = songInfo[1];
                string time = songInfo[2];

                songs.Add(new Song(typeList, name, time));
            }

            string printCommand = Console.ReadLine();

            if (printCommand == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (printCommand == song.TypeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }

        public class Song
        {
            public Song(string typeList, string name, string time)
            {
                TypeList = typeList;
                Name = name;
                Time = time;
            }
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
    }
}
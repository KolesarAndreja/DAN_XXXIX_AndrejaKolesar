using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_AndrejaKolesar
{
    class Song
    {
        #region property and field
        public string Author { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string fileName = @"..\..\Music.txt";
        #endregion


        #region constructors
        public Song() { }

        public Song(string author, string name, TimeSpan duration)
        {
            Author = author;
            Name = name;
            Duration = duration;
        }
        #endregion constructors


        #region reading and selecting song
        public override string ToString()
        {
            return Author + "," + Name + "," + Duration;
        }

        public List<Song> GetAllSongs()
        {
            List<Song> allSongs = new List<Song>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string authorOfSong = s.Split(',')[0];
                    string nameOfSong = s.Split(',')[1];
                    string durationOfSong = s.Split(',')[2];
                    TimeSpan.TryParse(durationOfSong, out TimeSpan d);
                    Song song = new Song(authorOfSong, nameOfSong, d);
                    allSongs.Add(song);
                }
            }
            return allSongs;
        }

        public void PrintAllSongs()
        {
            List<Song> songs = GetAllSongs();
            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine(i+1 + " - " + songs[i].ToString());
            }
        }

        public Song SelectOneSong()
        {
            List<Song> allSongs = GetAllSongs();
            PrintAllSongs();
            Console.Write("Select one song: ");
            int n = ValidNumber(allSongs.Count);
            return allSongs[n - 1];
        }
        #endregion


        #region Add
        public void AddSong()
        {
            //author
            Console.Write("Enter the Author of song: ");
            string author = Console.ReadLine();
            author = CheckIfNullOrEmpty(author);
            //name
            Console.Write("Enter the name of song: ");
            string songName = Console.ReadLine();
            songName = CheckIfNullOrEmpty(songName);
            //duration
            Console.Write("Enter the duration of a song [h, m, sec]. \nhours:");
            int h = ValidNumber(int.MaxValue);
            Console.Write("minutes: ");
            int m = ValidNumber(59);
            Console.Write("seconds: ");
            int s = ValidNumber(59);
            TimeSpan time = new TimeSpan(h, m, s);
            Song song = new Song(author, songName, time);
            //Add new song to file
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(song.ToString());
            }
        }
        #endregion


        #region validation methods
        //valid int input
        public static int ValidNumber(int limit)
        {
            string s = Console.ReadLine();
            int num;
            bool b = Int32.TryParse(s, out num);
            while (!b || num < 0 || num > limit)
            {
                Console.Write("Invalid input. Try again: ");
                s = Console.ReadLine();
                b = Int32.TryParse(s, out num);
            }
            return num;
        }

        public static string CheckIfNullOrEmpty(string word)
        {
            while (string.IsNullOrEmpty(word))
            {
                Console.Write("Invalid input. Try again: ");
                word = Console.ReadLine();
            }
            return word;
        }
        #endregion
    }
}

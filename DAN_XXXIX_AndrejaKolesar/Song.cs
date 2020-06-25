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
        
        //override ToString method
        public override string ToString()
        {
            return Author + "," + Name + "," + Duration;
        }

        /// <summary>
        /// Read all songs from file and return list of this songs
        /// </summary>
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
        /// <summary>
        /// Print songs from list of all songs 
        /// </summary>
        public void PrintAllSongs()
        {
            List<Song> songs = GetAllSongs();
            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine(i+1 + " - " + songs[i].ToString());
            }
        }

        /// <summary>
        /// Select single one song and return this Song
        /// </summary>
        /// <returns></returns>
        public Song SelectOneSong()
        {
            List<Song> allSongs = GetAllSongs();
            PrintAllSongs();

            Console.Write("*You can stop song with Tab key. \nSelect one song: ");
            int n = Validation.ValidNumber(allSongs.Count);
            return allSongs[n - 1];
        }
        #endregion


        #region Add
        /// <summary>
        /// Add new song to the file Music.txt. Ask user for all information of the song.
        /// </summary>
        public void AddSong()
        {
            //author
            Console.Write("Enter the Author of song: ");
            string author = Console.ReadLine();
            author = Validation.CheckIfNullOrEmpty(author);
            //name
            Console.Write("Enter the name of song: ");
            string songName = Console.ReadLine();
            songName = Validation.CheckIfNullOrEmpty(songName);
            //duration
            Console.Write("Enter the duration of a song [h, m, sec]. \nhours:");
            int h = Validation.ValidNumber(int.MaxValue);
            Console.Write("minutes: ");
            int m = Validation.ValidNumber(59);
            Console.Write("seconds: ");
            int s = Validation.ValidNumber(59);
            TimeSpan time = new TimeSpan(h, m, s);
            Song song = new Song(author, songName, time);
            //Add new song to file
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(song.ToString());
            }
        }
        #endregion




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIX_AndrejaKolesar
{
    class Player
    {
        Song song = new Song();
        List<string> allAds = Advertisement.GetAllAds();
        AutoResetEvent songReset = new AutoResetEvent(false);
        AutoResetEvent adReset = new AutoResetEvent(false);
        Random random = new Random();

        /// <summary>
        /// Select one song, play this song and display ads in same time
        /// </summary>
        /// <param name="songIsFinished"></param>
        public void PlaySong(bool songIsFinished)
        {
            Song mySong = song.SelectOneSong();
            DateTime time = DateTime.Now;
            string currentTime = time.ToLongTimeString();
            DateTime endTime = DateTime.Now + mySong.Duration;
            string endingTime = endTime.ToLongTimeString();
            Console.WriteLine("Current time: {0}    Current song: {1}", currentTime, mySong.Name);
            Timer timerSong = new Timer(new TimerCallback(SongInProgress), endTime, 0, 0);
            //ads are waiting. After song starts, ads will also start.
            adReset.WaitOne();
            Timer timerAds = new Timer(new TimerCallback(Advertise), null, 0, 200);
            //wait end of song
            songReset.WaitOne();
            timerSong.Dispose();
            timerAds.Dispose();
            songIsFinished = true;
        }

        /// <summary>
        /// Print one type of message in case when song is playing and different message when song ended.
        /// </summary>
        /// <param name="endingTime">Time when song will end</param>
        public void SongInProgress(object endingTime)
        {
            //ensure that song starts before ads
            adReset.Set();
            DateTime end = Convert.ToDateTime(endingTime);
            if(DateTime.Now < end)
            {
                Console.WriteLine("The song is playing...");
            }
            else
            {
                Console.WriteLine("The song has ended.");
                songReset.Set();
            }

        }

        /// <summary>
        /// Print random ad from list of all ads
        /// </summary>
        /// <param name="state"></param>
        public void Advertise(object state)
        {
            int n = random.Next(0, allAds.Count);
            Console.WriteLine(allAds[n]);

        }
    }
}

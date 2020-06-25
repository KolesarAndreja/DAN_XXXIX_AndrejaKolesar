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
        Advertisement myAds = new Advertisement();
        AutoResetEvent AutoReset = new AutoResetEvent(false);

        public void PlaySong()
        {
            Song mySong = song.SelectOneSong();
            DateTime time = DateTime.Now;
            string currentTime = time.ToLongTimeString();
            DateTime endTime = DateTime.Now + mySong.Duration;
            string endingTime = endTime.ToLongTimeString();

            Console.WriteLine("Current time: {0}    Current song: {1}       EndTime: {2}", currentTime, mySong.Name, endingTime );
            Timer timer = new Timer(new TimerCallback(SongInProgress), endTime, 0, 1000);
            AutoReset.WaitOne();
            timer.Dispose();
           

        }

        public void SongInProgress(object endingTime)
        {
            DateTime end = Convert.ToDateTime(endingTime);
            if(DateTime.Now < end)
            {
                Console.WriteLine("The song is in progress...");
            }
            else
            {
                Console.WriteLine("The song has ended.");
                AutoReset.Set();
            }

        }
    }
}

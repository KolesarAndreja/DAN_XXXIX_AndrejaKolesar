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

        public void PlaySong()
        {
            Song mySong = song.SelectOneSong();
            DateTime time = DateTime.Now;
            string currentTime = time.ToLongTimeString();
            DateTime endTime = DateTime.Now + mySong.Duration;
            string endingTime = endTime.ToLongTimeString();

            Console.WriteLine("Current time: {0}    Current song: {1}       EndTime: {2}", currentTime, mySong.Name, endingTime );
            Timer timerSong = new Timer(new TimerCallback(SongInProgress), endTime, 0, 1000);
            adReset.WaitOne();
            Timer timerAds = new Timer(new TimerCallback(Advertise), null, 0, 200);
            songReset.WaitOne();
            timerSong.Dispose();
            timerAds.Dispose();
        }

        public void SongInProgress(object endingTime)
        {
            adReset.Set();
            DateTime end = Convert.ToDateTime(endingTime);
            if(DateTime.Now < end)
            {
                Console.WriteLine("The song is in progress...");
            }
            else
            {
                Console.WriteLine("The song has ended.");
                songReset.Set();
            }

        }

        public void Advertise(object state)
        {
            int n = random.Next(0, allAds.Count);
            Console.WriteLine(allAds[n]);

        }
    }
}

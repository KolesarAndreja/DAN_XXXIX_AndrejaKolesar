using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_AndrejaKolesar
{
    class Advertisement
    {
        public static string fileName = @"..\..\Reklame.txt";

        /// <summary>
        /// Return all ads from file Reklame.txt
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllAds()
        {
            List<string> allAds = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string ad;
                while ((ad = sr.ReadLine()) != null)
                {
                    allAds.Add(ad);
                }
            }
            return allAds;
        }
    }
}

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
        public string fileName = @"..\..\Reklame.txt";

        public List<string> GetAllAds()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_AndrejaKolesar
{
    class Validation
    {
        public static string YesNo()
        {
            string choose = Console.ReadLine().ToLower();
            //BackToMainMenu(choose);
            while (choose != "yes" && choose != "y" && choose != "no" && choose != "n")
            {
                Console.Write("Invalid input. Try again: ");
                choose = Console.ReadLine().ToLower();
                //BackToMainMenu(choose);
            }
            return choose;
        }

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
    }
}

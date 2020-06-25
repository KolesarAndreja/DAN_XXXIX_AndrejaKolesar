using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIX_AndrejaKolesar
{
    class Program
    {
        public static AutoResetEvent go = new AutoResetEvent(false);
        public static void TurnOff()
        {
            Console.Clear();
            Console.WriteLine("Turning off audio player...");
            Thread.Sleep(2000);
        }

        //Menu for Audio Player
        static void Main(string[] args)
        {
            Song song = new Song();
            Player player = new Player();
            string selected;
            do
            {
                Console.WriteLine("Select one option: \n1.Add new song \n2.Show all songs and play one \n3.Exit");
                Console.Write("Your choice is: ");
                selected = Console.ReadLine();
                switch (selected)
                {
                    case "1":
                        song.AddSong();
                        break;
                    case "2":
                        bool playAgain = true;
                        while (playAgain)
                        {
                            player.PlaySong(false);
                            Console.WriteLine("Do you want one more song? [yes/no]");
                            string answer = Validation.YesNo();
                            if (answer == "no" || answer == "n")
                            {
                                playAgain = false;
                            }
                        }
                        break;
                    case "3":
                        break;
                    default:
                        Console.Write("Invalid input.Try again: ");
                        break;
                }

            } while (selected != "3");

        }
    }
}

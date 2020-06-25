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
        //delegate and event based on that delegate
        public delegate void Notification();
        public static event Notification onNotification;
        //raising event 
        public static void Notify()
        {
            if (onNotification != null)
            {
                onNotification();
            }
        }

        //Menu for Audio Player
        static void Main(string[] args)
        {
            Song song = new Song();
            
            Player player = new Player();
            onNotification = player.TurnOff;
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
                        player.PlaySong();
                        Console.Write("Do you want to turn off player? [yes,no] : ");
                        string answer = Validation.YesNo();
                        if (answer == "yes" || answer == "y")
                        {
                            Notify();
                            selected = "3";
                        }
                        break;
                    case "3":
                        Notify();
                        break;
                    default:
                        Console.Write("Invalid input. ");
                        break;
                }

            } while (selected != "3");

        }
    }
}
